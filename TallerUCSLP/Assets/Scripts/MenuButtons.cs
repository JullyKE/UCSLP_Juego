using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
	public void Level(string name)
	{
		SceneManager.LoadScene(name);
	}
	
	public void Exit()
	{
		Debug.Log("Sali");
		Application.Quit();
	}
}
