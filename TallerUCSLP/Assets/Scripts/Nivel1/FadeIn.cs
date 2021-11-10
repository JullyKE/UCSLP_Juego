using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
	public GameObject controles;
	
	void Start()
	{
		controles.SetActive(false);
	}
	
	public void ActivarControles()
	{
		controles.SetActive(true);
	}
}
