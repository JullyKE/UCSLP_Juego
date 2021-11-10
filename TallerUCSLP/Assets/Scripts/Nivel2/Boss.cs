using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
	public float speed;
	public float stopDistance;
	public float retreatDistance;
	public float startTimeBtwShot;
	public int dead;
	public int TotalHealtEnemy;
	public int healthEnemy;
	private float TimeBtwShots;
	public float time;
	public Sprite healthSR;
	public Sprite normalSR;
	
	Vector3 direccion;
	
	public GameObject shot;
	private Transform player;
	
	Transform firepoint1;
	Transform firepoint2;
	
	bool isHealt;
	SpriteRenderer sr;
	public GameObject cinematic;
	public PlayerShip pShip;
	
    // Start is called before the first frame update
    void Start()
    {
	    player = GameObject.FindGameObjectWithTag("Player").transform; 
	    TimeBtwShots = startTimeBtwShot;
	    firepoint1 = transform.Find("FirePoint1");
	    firepoint2 = transform.Find("FirePoint2");
	    healthEnemy = TotalHealtEnemy;
	    sr = GetComponent<SpriteRenderer>();
	    cinematic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
	    if (Vector2.Distance(transform.position, player.position) > stopDistance)
	    {
	    	transform.position = Vector2.MoveTowards(transform.position, player.position, speed *Time.deltaTime);
	    	direccion = Vector3.RotateTowards(transform.position,player.position, speed*Time.deltaTime,0.0f);
	    }
	    else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
	    {
	    	transform.position = Vector2.MoveTowards(transform.position, player.position, -speed *Time.deltaTime);
	    	direccion = Vector3.RotateTowards(transform.position,player.position, -speed*Time.deltaTime,0.0f);
	    }
	    else if (Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
	    {
	    	transform.position = transform.position;
	    }
	    
	    if (TimeBtwShots <= 0)
	    {
	    	Instantiate(shot,firepoint1.position,Quaternion.identity);
	    	Instantiate(shot,firepoint2.position,Quaternion.identity);
	    	TimeBtwShots = startTimeBtwShot;
	    }
	    else
	    {
	    	TimeBtwShots -= Time.deltaTime;
	    }
	    
	    //transform.rotation =Quaternion.LookRotation(direccion);
    }
    
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("BulletPlayer"))
		{
			if (!isHealt)
			{
				    StartCoroutine(VisualDamage());
			  	healthEnemy -= dead;
				    if (healthEnemy == 0)
				    {
					        healthEnemy = 0;
					        Destroy(other.gameObject);
					        cinematic.SetActive(true);
					        Destroy(gameObject);
			  	}
			  	Destroy(other.gameObject);
			}
		}
	}
	
	IEnumerator VisualDamage()
	{
		isHealt = true;
		sr.sprite = healthSR;
		yield return new WaitForSeconds(time);
		sr.sprite = normalSR;
		isHealt = false;
	}
}
