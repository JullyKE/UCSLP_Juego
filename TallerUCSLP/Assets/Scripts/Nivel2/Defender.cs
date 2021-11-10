using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defender : MonoBehaviour
{
	public float totalDefense;
	public float defense;
	public float damageDefen = 1f;
	public float time = 0.5f;
	public AudioSource audios;
	
	bool isDefent;
	SpriteRenderer sr;
	
	public Image azul;
	
	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
	}
	
	void Start()
	{
		totalDefense = PlayerPrefs.GetInt("azul", 0);
		defense = totalDefense;
		if (totalDefense == 0)
		{
			gameObject.SetActive(false);
			azul.fillAmount = 0;
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (!isDefent)
		{
			if (other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
			{
				defense -= damageDefen;
				azul.fillAmount = defense/totalDefense;
				audios.Play();
				StartCoroutine(VisualDamage());
				if (defense == 0)
				{
					Destroy(gameObject);
				}
			}
		}
	}
	
	IEnumerator VisualDamage()
	{
		isDefent = true;
		sr.color = Color.red;
		yield return new WaitForSeconds(time);
		sr.color = Color.white;
		isDefent = false;
	}
}
