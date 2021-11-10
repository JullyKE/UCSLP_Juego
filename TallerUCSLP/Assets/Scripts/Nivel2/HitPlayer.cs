using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
	public float hitNumber;
	GameObject player;
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			player.SendMessage("AddDamega", hitNumber);
			Destroy(gameObject);
		}
	}
}
