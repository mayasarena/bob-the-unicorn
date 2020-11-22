using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWater : MonoBehaviour
{
    public float speed;
    public int damage;
    public GameObject particles;
    public HealthManager healthManager;


    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(particles, transform.position, transform.rotation);
            healthManager.HurtPlayer(damage, true, gameObject.transform);
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}