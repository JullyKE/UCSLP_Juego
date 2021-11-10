using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public GameObject bulletPrefab;
	
	public float fireDelay = 0.25f;
	float cooldownTimer = 0;
	
	void Update()
	{
		cooldownTimer -= Time.deltaTime;
		if ((Input.GetButtonDown("Jump"))&& cooldownTimer <= 0)
		{
			cooldownTimer = fireDelay;
			
			Vector3 offset =transform.rotation * new Vector3(0,0.6f,0);
			Instantiate(bulletPrefab, transform.position + offset,transform.rotation);
		}
	}
	
	public void FireBotton()
	{
		cooldownTimer = fireDelay;
			
		Vector3 offset =transform.rotation * new Vector3(0,0.6f,0);
		Instantiate(bulletPrefab, transform.position + offset,transform.rotation);
	}
}
