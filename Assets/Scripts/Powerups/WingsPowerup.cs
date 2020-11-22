using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsPowerup : MonoBehaviour
{
    public AnimatorOverrideController flyingAnim;
    public float flyTime;
    private float timer;
    public RuntimeAnimatorController playerAnim;
    public Animator anim;
    private bool startTimer = false;
    public GameObject player;

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true; 
        GetComponent<BoxCollider2D>().enabled = true;
        timer = flyTime;
        startTimer = false;
    }

    void Update()
    {
        if (startTimer) // Start timer
        {
            timer -= Time.deltaTime;
            if (timer <= 0) // End timer
            {
                startTimer = false;
                player.GetComponent<PlayerController>().isFlying = false; // Tell player controller that player can fly
                anim.runtimeAnimatorController = playerAnim as RuntimeAnimatorController; // Change animator controller back to original
                Destroy(gameObject); // Destroy the game object
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) { 
        if (other.gameObject.tag == "Player") 
        { 
            GetComponent<SpriteRenderer>().enabled = false; // Disable renderer
            GetComponent<BoxCollider2D>().enabled = false; // Disable box collider
            other.GetComponent<PlayerController>().isFlying = true; // Tell player controller that player cannot fly
            anim.runtimeAnimatorController = flyingAnim as RuntimeAnimatorController; // Change animator controller
            startTimer = true; // Start the timer
        }
    }
}
