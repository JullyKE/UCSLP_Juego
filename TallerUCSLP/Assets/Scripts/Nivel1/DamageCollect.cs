using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageCollect : MonoBehaviour
{
	[Header("Enemy")]
	public int damageNumber;
	[Header("Coin")]
	public int colorNum;
	public float livingTime = 0.5f;
	
	public GameObject KeyB;
	public GameObject KeyR;
	public Sprite blue;
	public Sprite red;
	
	public GameObject coin;
	public GameObject effect;
	
	public AudioSource coinAudio;
	
	bool keyNum;
	
	void Start()
	{
		if(coin != null && effect != null)
		{
			coin.SetActive(true);
			effect.SetActive(false);
		}
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			if (gameObject.CompareTag("Enemy"))
			{
				other.SendMessage("AddDamage",damageNumber);
			}
			if (gameObject.CompareTag("Coin"))
			{
				other.SendMessage("AddCoin", colorNum);
				coinAudio.Play();
				coin.GetComponent<SpriteRenderer>().enabled = false;
				gameObject.GetComponent<CircleCollider2D>().enabled = false;
				effect.SetActive(true);
					Destroy(gameObject, livingTime);
			}
			if (gameObject.CompareTag("Key"))
			{
			   	keyNum= true;
			  	other.SendMessage("AddKey", keyNum);
				    if (gameObject.name == "KeyBlue")
							    {
					    	    KeyB.GetComponent<Image>().sprite = blue;
							    }
					 	else
					 	{
					 		KeyR.GetComponent<Image>().sprite = red;
					 	}
						
				    Destroy(gameObject);
			}
		}
	}
}
