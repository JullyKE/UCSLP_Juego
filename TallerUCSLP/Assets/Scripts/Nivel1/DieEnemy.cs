using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEnemy : MonoBehaviour
{
	public float timeDie = 0.5f;
	public float jumpForce = 10;
	
	public SpriteRenderer spriteEnemy;
	public SpriteRenderer effect;
	public GameObject enemyPref;
	public GameObject player;
	
	public CapsuleCollider2D triger;
	public CapsuleCollider2D col;
	
	public AudioSource enemyAudio;
	void Awake()
	{
		spriteEnemy.enabled = true;
		effect.enabled = false;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Foot"))
		{
			spriteEnemy.enabled = false;
			enemyAudio.Play();
			//effect.enabled = true;
			triger.enabled = false;
			player.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
			col.enabled = false;
			Destroy(enemyPref,timeDie);
		}
	}
}
