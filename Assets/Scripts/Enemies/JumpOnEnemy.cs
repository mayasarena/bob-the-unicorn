using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnEnemy : MonoBehaviour
{

    public int damageToGive;
    private Rigidbody2D rigidBody;
    public float bounce; // Amount of bounciness

    void Start()
    {
        rigidBody = transform.parent.GetComponent<Rigidbody2D>(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive); // Damage enemy on bounce
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, bounce); // Make player bounce 
        }
    }
}
