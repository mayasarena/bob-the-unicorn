using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreatheFire : MonoBehaviour
{
    public float speed;
    public PlayerController player;
    public int damage;
    public GameObject particles;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (player.transform.localScale.x < 0) // Check which way fire is being launched and alter the sprite scale and speed accordingly
        {
            speed = -speed; 
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
    
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y); // Update the velocity of the fire
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the fire hits something, destroy it and instantiate particles
        Instantiate(particles, transform.position, transform.rotation);
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().HurtEnemy(damage); // Damage the player
            Destroy(gameObject);
        }
        
        else
        {
            Destroy(gameObject);
        }
    }
}
