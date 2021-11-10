using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
	public float speed;
	
	PlayerDamage playerHealth;
	Transform player;
	Vector2 target;
	
	// Start is called before the first frame update 
    void Start()
    {
	    player = GameObject.FindGameObjectWithTag("Player").transform;
	    target = new Vector2(player.position.x, player.position.y);
	    playerHealth = GameObject.Find("Player").GetComponent<PlayerDamage>();
    }

    // Update is called once per frame
    void Update()
    {
	    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
	    if (transform.position.x == target.x && transform.position.y == target.y)
	    {
	    	DestroyBullet();
	    }
	    if (playerHealth.healt == 0)
	    {
	    	DestroyBullet();
	    }
    }
    
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") || other.CompareTag("Defender"))
		{
			DestroyBullet();
		}
	}
	
	void DestroyBullet()
	{
		Destroy(gameObject);
	}
}
