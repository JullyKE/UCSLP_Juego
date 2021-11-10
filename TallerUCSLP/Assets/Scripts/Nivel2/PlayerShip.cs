using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
	public float rotSpeed = 180f;
	public float speed = 5f;
	public Joystick joistickDigital;
	
    // Update is called once per frame
    void Update()
    {
	    Quaternion rot = transform.rotation;
	    float z = rot.eulerAngles.z;
	    float horizontalInput = Input.GetAxis("Horizontal");
	    horizontalInput += joistickDigital.Horizontal;
	    z-= horizontalInput * rotSpeed * Time.deltaTime;
	    rot = Quaternion.Euler(0,0,z);
	    transform.rotation = rot;
	    
	    Vector3 pos = transform.position;
	    float verticalInput = Input.GetAxis("Vertical");
	    verticalInput += joistickDigital.Vertical;
	    Vector3 velocity = new Vector3(0, verticalInput* speed * Time.deltaTime,0);
	    pos += rot * velocity;
	    
	    transform.position = pos;
    }
}
