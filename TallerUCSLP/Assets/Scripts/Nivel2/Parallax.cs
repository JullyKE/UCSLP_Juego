using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
	[Range (0f, 0.5f)]
	public float speed;
	public RawImage background;
	public RawImage start;
	
    // Update is called once per frame
    void Update()
    {
	    float finalSpeed = speed * Time.deltaTime;
	    background.uvRect = new Rect(0f, background.uvRect.y + finalSpeed, 1f, 1f);
	    start.uvRect = new Rect(0f, start.uvRect.y + finalSpeed * 4, 1f, 1f);
    }
}
