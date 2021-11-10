using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFire : MonoBehaviour
{
	public GameObject fireShoot;
	public AudioSource botonAudio;
	
	Animator anim;
	bool isFirst = true;
	
	void Awake()
	{
		anim = GetComponent<Animator>();
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.CompareTag("Player") && isFirst)
		{
			botonAudio.Play();
			fireShoot.SendMessage("InicialFire");
			anim.SetTrigger("Activate");
			isFirst = false;
		}
	}
}
