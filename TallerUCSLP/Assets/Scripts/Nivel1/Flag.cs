using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
	public int numCheck;
	Animator anim;
	private GameManager gm;
	int incrementa = 1;
	PlayerDamageCollect cV;
	PlayerDamageCollect cY;
	PlayerDamageCollect cB;
	
	public AudioSource flagAudio;
	
	void Awake()
	{
		anim = GetComponent<Animator>();
	}
	
	void Start()
	{
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
		cV = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamageCollect>();
		cY = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamageCollect>();
		cB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDamageCollect>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			switch (numCheck)
			{
			case 1:
				gm.uno += incrementa;
				if (gm.uno == 1)
				{
					flagAudio.Play();
					PlayerPrefs.SetInt("verde", cV.coinGr);
				}
				break;
			case 2:
				gm.dos += incrementa;
				if (gm.dos == 1)
				{
					flagAudio.Play();
					PlayerPrefs.SetInt("verde", cV.coinGr);
				}
				break;
			case 3:
				gm.tres += incrementa;
				if (gm.tres == 1)
				{
					flagAudio.Play();
					PlayerPrefs.SetInt("verde", cV.coinGr);
				}
				break;
			case 4:
				gm.cuatro += incrementa;
				if (gm.cuatro == 1)
				{
					flagAudio.Play();
					PlayerPrefs.SetInt("verde", cV.coinGr);
				}
				break;
			case 5:
				gm.cinco += incrementa;
				if (gm.cinco == 1)
				{
					flagAudio.Play();
					PlayerPrefs.SetInt("amarillo", cY.coinY);
				}
				break;
			case 6:
				gm.seis += incrementa;
				if (gm.seis == 1)
				{
					flagAudio.Play();
					PlayerPrefs.SetInt("amarillo", cY.coinY);
				}
				break;
			case 7:
				gm.siete += incrementa;
				if (gm.siete == 1)
				{
					flagAudio.Play();
					PlayerPrefs.SetInt("amarillo", cY.coinY);
				}
				break;
			case 8:
				gm.ocho += incrementa;
				if (gm.ocho == 1)
				{
					flagAudio.Play();
					PlayerPrefs.SetInt("amarillo", cY.coinY);
				}
				break;
			case 9:
				gm.nueve += incrementa;	
				if (gm.nueve == 1)
				{
					flagAudio.Play();
					PlayerPrefs.SetInt("amarillo", cY.coinY);
				}
				break;
			case 10:
				gm.dies += incrementa;
				if (gm.dies == 1)
				{
					flagAudio.Play();
					PlayerPrefs.SetInt("azul", cB.coinB);
				}
				break;
			case 11:
				gm.once += incrementa;
				if (gm.once == 1)
				{
					flagAudio.Play();
					PlayerPrefs.SetInt("azul", cB.coinB);
				}
				break;
			}
			gm.checkPointNum = numCheck;
			gm.lastCheckPointPos = transform.position;
			anim.SetTrigger("Active");
		}
	}
}
