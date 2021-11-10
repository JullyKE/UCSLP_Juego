using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBase : MonoBehaviour
{
	public GameObject off;
	public GameObject on;
	
	void Awake()
	{
		on.SetActive(false);
		off.SetActive(true);
	}
   
	void InicialFire()
	{
		on.SetActive(true);
		off.SetActive(false);
	}
	
}
