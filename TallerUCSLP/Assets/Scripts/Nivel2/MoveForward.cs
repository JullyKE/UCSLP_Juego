using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
	public float speed = 5f;
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3(0, speed * Time.deltaTime,0);
		pos += transform.rotation * velocity;
		transform.position = pos;
	}
}
