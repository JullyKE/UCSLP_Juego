using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Borders{
	public float left;
	public float right;
	public float inferior;
	public float superior;
}
public class ToroiddaUniverse : MonoBehaviour
{
	public Borders borders;
	
    // Update is called once per frame
    void Update()
    {
	    Vector2 pos = transform.position;
	    float x = transform.position.x;
	    float y = transform.position.y;
	    
	    float screenRatio = (float)Screen.width/(float)Screen.height;
	    float widthOrtho = Camera.main.orthographicSize * screenRatio;
	    
	    borders.right = widthOrtho;
	    borders.left = - widthOrtho;
	    
	    if (x > borders.right)
	    {
	    	pos.x = borders.left;
	    	transform.position = pos;
	    }
	    if (x < borders.left)
	    {
	    	pos.x = borders.right;
	    	transform.position = pos;
	    }
	    if (y > borders.superior)
	    {
	    	pos.y = borders.inferior;
	    	transform.position = pos;
	    }
	    if (y < borders.inferior)
	    {
	    	pos.y = borders.superior;
	    	transform.position = pos;
	    }
    }
}
