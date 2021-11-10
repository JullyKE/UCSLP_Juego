using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
	public float time = 0.2f;
	public Sprite healthSR;
	public Sprite normalSR;
	bool isHealt;
	public SpriteRenderer sr;
	public int dead;
	public int TotalHealtEnemy;
	public int healthEnemy;
	public GameObject player;
	public AudioSource audioEnemy;
	
	void Start()
	{
		healthEnemy = TotalHealtEnemy;
		audioEnemy.enabled = false;
	}
	
	void Update()
	{
		if (player == null )
		{
			player = GameObject.FindWithTag("Player");
		}
	    
		if (player == null)
		{
			return;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("BulletPlayer"))
		{
			if (!isHealt)
			{
			  	healthEnemy -= dead;
				StartCoroutine(VisualDamage());
				player.GetComponent<PlayerDamage>().AddEnemy(1);
				   if (healthEnemy == 0)
				   {
					   healthEnemy = 0;
					   audioEnemy.enabled = true;
					        Destroy(other.gameObject);
					        Destroy(gameObject);
				   }
				   Destroy(other.gameObject);
			}
		}
		if (other.CompareTag("Defender"))
		{
			if (!isHealt)
			{
				    healthEnemy -= dead;
			   	StartCoroutine(VisualDamage());
				    player.GetComponent<PlayerDamage>().AddEnemy(1);
				    if (healthEnemy == 0)
			  	{
			  		healthEnemy = 0;
					        Destroy(gameObject);
				    }
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
