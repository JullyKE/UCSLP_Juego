using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firingNow : MonoBehaviour
{
	public GameObject firePrefab;
	public float aimingTime = 0.5f;
	public float shotTime = 1.5f;
	//public AudioSource firesound;
	
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
			//firesound.Play();
			
			if (transform.localScale.y < 0f)
			{
				fireScript.direccion = Vector2.down;
			}
			if (transform.localScale.y > 0f)
			{
				fireScript.direccion = Vector2.up;
			}
		}
	}
	
	public IEnumerator Fire2()
	{
		yield return new WaitForSeconds(aimingTime);
		
		FireNowActivate();
		
		yield return new WaitForSeconds(shotTime);
		
	}
}
