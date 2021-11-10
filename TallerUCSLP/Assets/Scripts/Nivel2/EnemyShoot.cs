using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
	public GameObject bulletPrefab;
	
	public float fireDelay = 0.5f;
	float cooldownTimer = 0;
	
	Transform player;
	
	void Update()
	{
		if (player == null )
		{
			GameObject go = GameObject.FindWithTag("Player");
			if(go != null)
			{
				player = go.transform;
			}
		}
		
		cooldownTimer -= Time.deltaTime;
		if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 4f)
		{
			cooldownTimer = fireDelay;
			
			Vector3 offset =transform.rotation * new Vector3(0,0.6f,0);
			Instantiate(bulletPrefab, transform.position + offset,transform.rotation);
		}
	}
}
