using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonFire : MonoBehaviour
{
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
        if (right)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (up)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed);
        }

        if (!right && !up)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(particles, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            healthManager.HurtPlayer(damage, true, gameObject.transform);
            Destroy(transform.parent.gameObject);
        }

        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
