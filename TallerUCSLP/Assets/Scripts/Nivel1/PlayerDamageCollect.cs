using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageCollect : MonoBehaviour
{
	public int totalHealth = 3;
	public int totalCoin = 3;
	public float time = 0.1f;
	public LayerMask rockLayer;
	public float jumpForce;
	public GameManager gm;
	public AudioSource deadAudio;
	public AudioSource enemyAudio;
	public AudioSource keyAudio;

	public RuntimeAnimatorController[] animController;
	
	public Text green;
	public Text yellow;
	public Text blue;
	public Text keyB;
	public Text keyR;
	
	public GameObject greenImage;
	public GameObject yellowImage;
	public GameObject blueImage;
	public GameObject keyBImage;
	public GameObject keyRImage;
	public GameObject greenTxt;
	public GameObject yellowTxt;
	public GameObject blueTxt;
	public GameObject fadeOut;
	
	Animator anim;
	Transform rockPoint;
	
	[HideInInspector]
	public int health;
	[HideInInspector]
	public int coinB;
	[HideInInspector]
	public int coinY;
	[HideInInspector]
	public int coinGr;
	bool isHealth;
	bool isAplasta;
	bool key;
	int point = 1;
	[HideInInspector]
	public int verde;
	[HideInInspector]
	public int azul;
	[HideInInspector]
	public int amarillo;
	
	float rockRadio = 0.5f;
	bool rockHead;
	
	Vector2 lpGM;
	
	void Awake()
	{
		anim = GetComponent<Animator>();
		rockPoint = transform.Find("Head");
		
		greenImage.SetActive(false);
		greenTxt.SetActive(false);
		yellowImage.SetActive(false);
		yellowTxt.SetActive(false);
		blueImage.SetActive(false);
		blueTxt.SetActive(false);
		keyBImage.SetActive(false);
		keyRImage.SetActive(false);
		
		green.text = "00/10";
		yellow.text = "00/10";
		blue.text = "00/10";
		
		verde = PlayerPrefs.GetInt("verde",0);
		azul = PlayerPrefs.GetInt("azul",0);
		amarillo = PlayerPrefs.GetInt("amarillo",0);
		
		fadeOut.SetActive(false);
	}
	
    void Start()
	{
	    health = totalHealth;
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		
		switch (gm.checkPointNum)
		{
		case 1:
			PlayerPrefs.SetInt("coinGr", verde);
			coinGr = PlayerPrefs.GetInt("coinGr", 0);
			break;
		case 2:
			PlayerPrefs.SetInt("coinGr", verde);
			coinGr = PlayerPrefs.GetInt("coinGr", 0);
			green.text = "0" + coinGr.ToString() + "/10";
			greenImage.SetActive(true);
			greenTxt.SetActive(true);
			break;
		case 3:
			PlayerPrefs.SetInt("coinGr", verde);
			coinGr = PlayerPrefs.GetInt("coinGr", 0);
			green.text = "0" + coinGr.ToString() + "/10";
			greenImage.SetActive(true);
			greenTxt.SetActive(true);
			break;
		case 4:
			PlayerPrefs.SetInt("coinGr", verde);
			coinGr = PlayerPrefs.GetInt("coinGr", 0);
			green.text = "0" + coinGr.ToString() + "/10";
			greenImage.SetActive(true);
			greenTxt.SetActive(true);
			break;
		case 5:
			PlayerPrefs.SetInt("coinGr", verde);
			coinGr = PlayerPrefs.GetInt("coinGr", 0);
			green.text = "0" + coinGr.ToString() + "/10";
			greenImage.SetActive(true);
			greenTxt.SetActive(true);
			
			PlayerPrefs.SetInt("coinY", amarillo);
			coinY = PlayerPrefs.GetInt("coinY", 0);
			yellow.text = "0" + coinY.ToString() + "/10";
			yellowImage.SetActive(true);
			yellowTxt.SetActive(true);
			break;
		case 6:
			PlayerPrefs.SetInt("coinGr", verde);
			coinGr = PlayerPrefs.GetInt("coinGr", 0);
			green.text = "0" + coinGr.ToString() + "/10";
			greenImage.SetActive(true);
			greenTxt.SetActive(true);
			
			PlayerPrefs.SetInt("coinY", amarillo);
			coinY = PlayerPrefs.GetInt("coinY", 0);
			yellow.text = "0" + coinY.ToString() + "/10";
			yellowImage.SetActive(true);
			yellowTxt.SetActive(true);
			break;
		case 7:
			PlayerPrefs.SetInt("coinGr", verde);
			coinGr = PlayerPrefs.GetInt("coinGr", 0);
			green.text = "0" + coinGr.ToString() + "/10";
			greenImage.SetActive(true);
			greenTxt.SetActive(true);
			
			PlayerPrefs.SetInt("coinY", amarillo);
			coinY = PlayerPrefs.GetInt("coinY", 0);
			yellow.text = "0" + coinY.ToString() + "/10";
			yellowImage.SetActive(true);
			yellowTxt.SetActive(true);
			break;
		case 8:
			PlayerPrefs.SetInt("coinGr", verde);
			coinGr = PlayerPrefs.GetInt("coinGr", 0);
			green.text = "0" + coinGr.ToString() + "/10";
			greenImage.SetActive(true);
			greenTxt.SetActive(true);
			
			PlayerPrefs.SetInt("coinY", amarillo);
			coinY = PlayerPrefs.GetInt("coinY", 0);
			yellow.text = "0" + coinY.ToString() + "/10";
			yellowImage.SetActive(true);
			yellowTxt.SetActive(true);
			break;
		case 9:
			PlayerPrefs.SetInt("coinGr", verde);
			coinGr = PlayerPrefs.GetInt("coinGr", 0);
			green.text = "0" + coinGr.ToString() + "/10";
			greenImage.SetActive(true);
			greenTxt.SetActive(true);
			
			PlayerPrefs.SetInt("coinY", amarillo);
			coinY = PlayerPrefs.GetInt("coinY", 0);
			yellow.text = "0" + coinY.ToString() + "/10";
			yellowImage.SetActive(true);
			yellowTxt.SetActive(true);
			
			PlayerPrefs.SetInt("coinB", 0);
			coinB = PlayerPrefs.GetInt("coinB", 0);
			break;
		case 10:
			PlayerPrefs.SetInt("coinGr", verde);
			coinGr = PlayerPrefs.GetInt("coinGr", 0);
			green.text = "0" + coinGr.ToString() + "/10";
			greenImage.SetActive(true);
			greenTxt.SetActive(true);
			
			PlayerPrefs.SetInt("coinY", amarillo);
			coinY = PlayerPrefs.GetInt("coinY", 0);
			yellow.text = "0" + coinY.ToString() + "/10";
			yellowImage.SetActive(true);
			yellowTxt.SetActive(true);
			
			PlayerPrefs.SetInt("coinB", azul);
			coinB = PlayerPrefs.GetInt("coinB", 0);
			blue.text = "0" + coinY.ToString() + "/10";
			blueImage.SetActive(true);
			blueTxt.SetActive(true);
			break;
		case 11:
			PlayerPrefs.SetInt("coinGr", verde);
			coinGr = PlayerPrefs.GetInt("coinGr", 0);
			green.text = "0" + coinGr.ToString() + "/10";
			greenImage.SetActive(true);
			greenTxt.SetActive(true);
			
			PlayerPrefs.SetInt("coinY", amarillo);
			coinY = PlayerPrefs.GetInt("coinY", 0);
			yellow.text = "0" + coinY.ToString() + "/10";
			yellowImage.SetActive(true);
			yellowTxt.SetActive(true);
			
			PlayerPrefs.SetInt("coinB", azul);
			coinB = PlayerPrefs.GetInt("coinB", 0);
			blue.text = "0" + coinY.ToString() + "/10";
			blueImage.SetActive(true);
			blueTxt.SetActive(true);
			
			keyBImage.SetActive(false);
			keyRImage.SetActive(true);
			break;
		default:
			PlayerPrefs.SetInt("coinGr", 0);
			coinGr = PlayerPrefs.GetInt("coinGr", 0);
			break;
		}
    }
    
	void AddDamage(int ammount)
	{
		if (!isHealth)
		{
			health -= ammount;
			StartCoroutine(VisualDamage());
			enemyAudio.Play();
		
			if (health <= 0)
			{
				deadAudio.Play();
				health = 0;
				fadeOut.SetActive(true);
			}
		}
	}
	
	void AddCoin(int color)
	{
		switch (color)
		{
		case 1: 
			if (coinGr >= totalCoin)
			{
				//coinGr = totalCoin;
				PlayerPrefs.SetInt("coinGr", totalCoin);
				coinGr = PlayerPrefs.GetInt("coinGr", 0);
				green.text = coinGr.ToString() + "/10";
				
			}
			else
			{
				//coinGr += point;
				PlayerPrefs.SetInt("coinGr", coinGr + point);
				coinGr = PlayerPrefs.GetInt("coinGr", 0);
				green.text = "0" + coinGr.ToString() + "/10";
				
			}
				 	break;
		case 2:
			if (coinY >= totalCoin)
			{
				//	coinY = totalCoin;
				PlayerPrefs.SetInt("coinY", totalCoin);
				coinY = PlayerPrefs.GetInt("coinY", 0);
				yellow.text = coinY.ToString() + "/10";
			
			}
			else
			{
				//coinY += point;
				PlayerPrefs.SetInt("coinY", coinY + point);
				coinY = PlayerPrefs.GetInt("coinY", 0);
				yellow.text = "0" + coinY.ToString() + "/10";
				
			}
					break;
		case 3: 
			if (coinB >= totalCoin)
			{
				//coinB = totalCoin;
				PlayerPrefs.SetInt("coinB", totalCoin);
				coinB = PlayerPrefs.GetInt("coinB", 0);
				blue.text = coinB.ToString() + "/10";
			}
			else
			{
				//coinB += point;
				PlayerPrefs.SetInt("coinB", coinB + point);
				coinB = PlayerPrefs.GetInt("coinB", 0);
				blue.text = "0" + coinB.ToString() + "/10";
			}
				break;
		}
	}
	
	void AddKey(bool take)
	{
		if (!take)
		{
			Debug.Log("Consigue la llave");
		}
		else
		{
			key = true;
			keyAudio.Play();
		}
	}
	
	IEnumerator VisualDamage()
	{
		isHealth = true;
		
		anim.SetTrigger("Hit");
		
		yield return new WaitForSeconds(time);
		
		if (health != 0)
		{
			anim.runtimeAnimatorController = animController[health - 1];
		}
		
		isHealth = false;
	}
	
	void OnCollisionStay2D(Collision2D col)
	{
		if (col.collider.CompareTag("Door") && key)
		{
			key = false;
			Destroy(col.collider.gameObject);
			
			if (col.gameObject.name == "DoorBlue")
			{
				keyBImage.SetActive(false);
				keyAudio.Play();
			}
			else if (col.gameObject.name == "DoorRed")
			{
				keyRImage.SetActive(false);
				keyAudio.Play();
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (!isAplasta)
		{
			rockHead = Physics2D.OverlapCircle(rockPoint.position, rockRadio, rockLayer);
			if (rockHead)
			{
				StartCoroutine(VisualAplata());
				AddDamage(2);
			}
		}
	}
	
	IEnumerator VisualAplata()
	{
		isAplasta = true;
		
		anim.SetTrigger("Aplasta");
		
		yield return new WaitForSeconds(time);
		
		anim.runtimeAnimatorController = animController[health - 1];
		
		isAplasta = false;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Snap"))
		{
			deadAudio.Play();
		}
		if (other.CompareTag("BosqueCoin"))
		{
			greenImage.SetActive(true);
			greenTxt.SetActive(true);
		}
		if (other.CompareTag("DesiertoCoin"))
		{
			yellowImage.SetActive(true);
			yellowTxt.SetActive(true);
		}
		if (other.CompareTag("NieveCoin"))
		{
			blueImage.SetActive(true);
			blueTxt.SetActive(true);
		}
		if (other.CompareTag("KeyUI"))
		{
			keyBImage.SetActive(true);
			keyRImage.SetActive(true);
		}
		if (other.gameObject.name == "Sprite")
		{
			gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
		}
	}
}
