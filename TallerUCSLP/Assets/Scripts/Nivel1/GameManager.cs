using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	public Vector2 lastCheckPointPos;
	public int checkPointNum;
	public AudioSource audioGM;
	
	//[HideInInspector]
	public int uno;
	public int dos;
	public int tres;
	public int cuatro;
	public int cinco;
	public int seis;
	public int siete;
	public int ocho;
	public int nueve;
	public int dies;
	public int once;
	
	void Awake()
	{
		uno = 0;
		dos = 0;
		tres = 0;
		cuatro = 0;
		cinco = 0;
		seis = 0;
		siete = 0;
		ocho = 0;
		nueve = 0;
		dies = 0;
		once = 0;
		checkPointNum = 0;
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(instance); 
		}
		else
		{
			Destroy(gameObject);
		}
	}
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}
         
	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}
         
	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		if (scene.name != "Game")
		{
			audioGM.enabled = false;
		}
		else
		{
			audioGM.enabled = true;
		}
		
		if (scene.name  == "Menu")
		{
			lastCheckPointPos = new Vector3(-7f, -3.28f);
			PlayerPrefs.SetInt("verde", 0);
			PlayerPrefs.SetInt("amarillo", 0);
			PlayerPrefs.SetInt("azul", 0);
		}
	}
}
