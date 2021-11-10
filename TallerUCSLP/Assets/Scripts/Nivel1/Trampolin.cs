using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
	public float jumpForce;
	public AudioSource tramAudio;
	
	Animator anim;
	
	void Awake()
	{
		anim = GetComponent<Animator>();
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.CompareTag("Player"))
		{
			tramAudio.Play();
			col.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce); 
			anim.SetTrigger("Activate");
		}
	}
}
