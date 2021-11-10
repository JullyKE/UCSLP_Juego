using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour
{
	public float timeDelay;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			StartCoroutine(Espera(other));
		}
	}
	
	IEnumerator Espera(Collider2D other)
	{
		other.gameObject.SetActive(false);
		
		yield return new WaitForSeconds(timeDelay);
		
		SceneManager.LoadScene("Cinematica");
	}
}
