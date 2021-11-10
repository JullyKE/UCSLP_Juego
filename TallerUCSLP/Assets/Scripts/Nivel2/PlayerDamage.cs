using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
	public int totalhealt;
	public float time;
	public float timeDie;
	public GameObject explosion;
	public ParticleSystem ps;
	public int totalenemies;
	public EnemySpawn es;
	public Image verde;
	public AudioSource hit;
	
	public float healt;
	public float healtTotal;
	bool isHealt;
	
	SpriteRenderer sr;
	PolygonCollider2D pCollider;
	
	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		pCollider = GetComponent<PolygonCollider2D>();
	}
	
	void Start()
	{
		totalhealt = PlayerPrefs.GetInt("verde", 5);
		healt = totalhealt * 2;
		healtTotal = healt;
		explosion.SetActive(false);
	}
	
	public void AddDamega(int ammount)
	{
		if (!isHealt)
		{
			StartCoroutine(VisualDamage());
			healt -= ammount;
			
			verde.fillAmount = healt/healtTotal;
			hit.Play();
			if (healt <= 0)
			{
				 	StartCoroutine(Muerte());
				 	healt = 0;
			}
			
		}
	}
	
	public void AddEnemy(int ammount)
	{
		totalenemies += ammount;
		if (totalenemies >= es.numberInicial)
		{
			SceneManager.LoadScene("Win");
		}
	}
	
	IEnumerator VisualDamage()
	{
		isHealt = true;
		sr.color = Color.red;
		yield return new WaitForSeconds(time);
		sr.color = Color.white;
		isHealt = false;
	}
	
	IEnumerator Muerte()
	{
		sr.enabled = false;
		pCollider.enabled = false;
		ps.Stop();
		explosion.SetActive(true);
		yield return new WaitForSeconds(timeDie);
		SceneManager.LoadScene("Nivel2");
	}
}
