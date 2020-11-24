using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonFire : MonoBehaviour
{
    // Options for what direction the fireball is being launched
    public float speed;
    public bool right;
    public bool up;

    public int damage;
    public HealthManager healthManager;
    public GameObject particles;

    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    void Update()
    {
        if (right) // If the fireball is being launched right, make it go right
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (up) // fireball up
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed);
        }

        if (!right && !up) // fireball left
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Fun particles
        Instantiate(particles, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            healthManager.HurtPlayer(damage, true, gameObject.transform); // Damage the player
            Destroy(transform.parent.gameObject);
        }

        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
