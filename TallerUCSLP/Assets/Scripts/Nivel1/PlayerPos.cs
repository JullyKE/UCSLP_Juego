using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerPos : MonoBehaviour
{
	private GameManager gm;
	public PlayerDamageCollect pD;
	public float time;
	public GameObject fadeOut;
    // Start is called before the first frame update
    void Start()
    {
	    gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
	    transform.position = gm.lastCheckPointPos;
	    fadeOut.SetActive(false);
    }
    
	void Update()
	{
		if (pD.health <= 0)
		{
			StartCoroutine(DiePlayer());
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Snap"))
		{
			StartCoroutine(DiePlayer());
			fadeOut.SetActive(true);
		}
	}
	
	IEnumerator DiePlayer()
	{
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
