using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Also evil lava
public class EvilWater : MonoBehaviour
{
    public float speed; // Speed of object
    public int damage; // Damage it gives player
    public GameObject particles; 
    public HealthManager healthManager;


    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed); // Update the object velocity
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(particles, transform.position, transform.rotation); // Damage player if hit
            healthManager.HurtPlayer(damage, true, gameObject.transform);
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}