using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
	public float speed = 5f;
	public Vector2 direccion = new Vector2(0,0);
	public float livingTime = 20f;
	public float time = 1.5f;
	public float timeBlack = 1.5f;
	
	Rigidbody2D rb;
	
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
    
    void Start()
    {
	    Destroy(gameObject,livingTime);
    }
    
	void FixedUpdate()
	{
		Vector2 move = direccion.normalized * speed;
		rb.velocity = move;
	}
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			gameObject.transform.GetComponent<SpriteRenderer>().enabled = false;
			StartCoroutine(ChangeColor(other.gameObject));
			other.SendMessage("AddDamage", 1);
		}
	}
	
	IEnumerator ChangeColor(GameObject player)
	{
		player.transform.GetComponent<SpriteRenderer>().color = Color.black;
		
		yield return new WaitForSeconds(timeBlack);
		
		player.transform.GetComponent<SpriteRenderer>().color = Color.white;
		
		yield return new WaitForSeconds(time);
		
		Destroy(gameObject);
	}
}
