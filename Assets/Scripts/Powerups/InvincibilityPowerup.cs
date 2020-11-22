using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerup : MonoBehaviour
{
    public float invincibleTime;
    public float timer;
    private bool startTimer = false;
    public GameObject rainbowEmblem;
    public GameObject player;
    public HealthManager healthManager;

    void Start()
    {
        timer = invincibleTime;
        startTimer = false;
        rainbowEmblem.GetComponent<SpriteRenderer>().enabled = false; 
        GetComponent<SpriteRenderer>().enabled = true; 
        GetComponent<BoxCollider2D>().enabled = true; 
    }

    void Update()
    {
        if (startTimer) // Start timer
        {
            timer -= Time.deltaTime;
            if (timer <= 0) // End timer
            {
                startTimer = false;
                healthManager.isInvincible = false;
                rainbowEmblem.GetComponent<SpriteRenderer>().enabled = false; 
                Destroy(gameObject); // Destroy the game object
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) { 
        if (other.gameObject.tag == "Player") 
        { 
            healthManager.isInvincible = true;
            rainbowEmblem.GetComponent<SpriteRenderer>().enabled = true; 
            GetComponent<SpriteRenderer>().enabled = false; 
            GetComponent<BoxCollider2D>().enabled = false; 
            startTimer = true; // Start the timer
        }
    }
}