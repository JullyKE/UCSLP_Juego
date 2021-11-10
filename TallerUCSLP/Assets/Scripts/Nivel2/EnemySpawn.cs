using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	float enemyRate = 5f;
	float nextEnemy = 1f;
	public int totalnum;
	public int number;
	public int numberInicial;
	
	public GameObject enemyPref;
	public float spawnDistance = 20f;
	
	void Awake()
	{
		totalnum = PlayerPrefs.GetInt("amarillo", 10);
		number = 15 - totalnum;
		numberInicial = number;
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		nextEnemy -= Time.deltaTime;
		if (nextEnemy <= 0 && number > 0)
		{
			nextEnemy = enemyRate;
			enemyRate *= 0.2f;
			if (enemyRate < 2)
			{
				enemyRate = 2;
			}
			Vector3 offset;
			offset.y = Random.Range(-3f, 3f);
			offset.x = Random.Range(-7f, 7f);
			offset.z = 0;
				offset = offset.normalized * spawnDistance;
			Instantiate(enemyPref,transform.position + offset,Quaternion.identity);
			number--;
		}
	}
}
