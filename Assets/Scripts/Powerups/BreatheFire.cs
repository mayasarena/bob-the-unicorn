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

        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
    
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(particles, transform.position, transform.rotation);
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().HurtEnemy(damage);
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
