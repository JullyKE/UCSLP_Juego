using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//universo cambiante
public class PlayerController : MonoBehaviour
{
	public Joystick joistickDigital;
	public float speed = 10f;
	public float jumpForce = 10f;
	public float snowVelocity = 0.1f;
	public LayerMask groundLayer;
	public LayerMask snowLayer;
	
	Rigidbody2D rb;
	Animator anim;
	Transform groundPoint;
	
	Vector2 moveHorizontal;
	bool isGrounded;
	bool isJump;
	bool isBeterJump = true;
	float groundRadio = 0.5f;
	bool isSnow;
	bool flipX;
	bool dobleJump;
	bool puede;
	public float fallMultiplier= 0.5f;
	public float lowMultiplier = 1f;
	
	public GameObject fadeIn;
	public AudioSource jumpAudio;
	
	
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		groundPoint = transform.Find("GroundedPoint");
	}
    
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		fadeIn.SetActive(true);
	}
    void Update()
    {
	    float horizontalInput = Input.GetAxisRaw("Horizontal");
	    horizontalInput += joistickDigital.Horizontal;
	    moveHorizontal = new Vector2(horizontalInput, 0f);
	    //puede = (joistickDigital.Vertical > 0.9f);
	    
	    if(horizontalInput < 0 && !flipX)
	    {
	    	Flip();
	    }
	    else if (horizontalInput > 0 && flipX)
	    {
	    	Flip();
	    }
	    
	    isGrounded = Physics2D.OverlapCircle(groundPoint.position, groundRadio, groundLayer);
	    isSnow = Physics2D.OverlapCircle(groundPoint.position, groundRadio, snowLayer);
	    
	    if (isGrounded || isSnow)
	    {
	    	dobleJump = true;
	    }
	    
	    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Jump") || puede)
	    {
	    	if (isGrounded || isSnow)
	    	{
		    			 	isJump = true;
		    	dobleJump = true;
	    	}
	    	else if (dobleJump)
	    	{
		    		    isJump = true;
		    	dobleJump = false;
	    	}
	    }
    }
	
	void FixedUpdate()
	{
		float horizontalVelocity;
		
		if (isSnow)
		{
			horizontalVelocity = moveHorizontal.normalized.x * speed + snowVelocity;
			rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
		}
		else
		{
			horizontalVelocity = moveHorizontal.normalized.x * speed;
			rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
		}
		
		if(isJump)
		{
			jumpAudio.Play();
			rb.velocity = new Vector2(rb.velocity.x, 0f);
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			isJump = false;
		}
		
		if (isBeterJump)
		{
			if (rb.velocity.y < 0)
			{
				rb.velocity += Vector2.up * Physics2D.gravity.y *(fallMultiplier) * Time.deltaTime;
			}
					
			if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
			{
				rb.velocity += Vector2.up * Physics2D.gravity.y * (lowMultiplier) * Time.deltaTime;
			}
		}
		
	}
	
	void LateUpdate()
	{
		anim.SetBool("Idle", moveHorizontal == Vector2.zero);
		anim.SetBool("IsGrounded", (isGrounded || isSnow));
		anim.SetFloat("VerticalVelocity", rb.velocity.y);
	}
	
	void Flip()
	{
		flipX = !flipX;
		float localScaleX = transform.localScale.x;
		localScaleX *= -1;
		snowVelocity *= -1;
		transform.localScale = new Vector3(localScaleX, 1f, 1f);
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.CompareTag("Plataforma"))
		{
			transform.parent = col.transform;
		}
	}
	
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.collider.CompareTag("Plataforma"))
		{
			transform.parent = null;
		}
	}
	
	public void SaltarBoton()
	{
		if (isGrounded || isSnow)
		{
			isJump = true;
			dobleJump = true;
		}
		else if (dobleJump)
		{
			isJump = true;
			dobleJump = false;
		}
	}
}
