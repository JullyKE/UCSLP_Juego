using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataform : MonoBehaviour
{
	public float velocity = 2f;
	
	public GameObject objectMove;
	public Transform startPoint;
	public Transform endPoint;
	
	public SpriteRenderer sr;
	
	Vector3 mover;
	
	void Start()
	{
		mover = endPoint.position;
	}

	void Update()
	{
		objectMove.transform.position = Vector3.MoveTowards(objectMove.transform.position,mover, velocity * Time.deltaTime);
	    
		if (objectMove.transform.position == endPoint.position)
		{
			mover = startPoint.position;
			if (gameObject.CompareTag("Enemy"))
			{
				sr.flipX = true;
			}
		}
		if (objectMove.transform.position == startPoint.position)
		{
			mover = endPoint.position;
			if (gameObject.CompareTag("Enemy"))
			{
				sr.flipX = false;
			}
		}
	}
}
