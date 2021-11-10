using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firingNowld : MonoBehaviour
{
	public GameObject firePrefab;
	public AudioSource firesound;
	
	Transform firePoint;
	
	void Awake()
	{
		firePoint = transform.Find("FirePoint");
	}
	
	public void FireNowActivate()
	{
		if (firePrefab != null && firePoint != null)
		{
			GameObject myFire = Instantiate(firePrefab,firePoint.position,Quaternion.identity) as GameObject;
			fire fireScript = myFire.GetComponent<fire>();
			firesound.Play();
			
			if (transform.localScale.x < 0f)
			{
				fireScript.direccion = Vector2.left;
			}
			if (transform.localScale.x > 0f)
			{
				fireScript.direccion = Vector2.right;
			}
		}
	}
}
