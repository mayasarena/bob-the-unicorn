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
    private AudioSource collectionAudio;

    void Start()
    {
        timer = invincibleTime;
        startTimer = false;
        rainbowEmblem.GetComponent<SpriteRenderer>().enabled = false; // Make sure rainbow emblem is hidden
        GetComponent<SpriteRenderer>().enabled = true; 
        GetComponent<BoxCollider2D>().enabled = true; 
        collectionAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (startTimer) // Start timer
        {
            timer -= Time.deltaTime;
            if (timer <= 0) // End timer
            {
                startTimer = false;
                healthManager.isInvincible = false; // Player is no longer invincible
                rainbowEmblem.GetComponent<SpriteRenderer>().enabled = false; // Disable emblem
                Destroy(gameObject); // Destroy the game object when time is up
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) { 
        if (other.gameObject.tag == "Player") 
        { 
            collectionAudio.Play();
            healthManager.isInvincible = true; // Tell health manager that player is invincible
            rainbowEmblem.GetComponent<SpriteRenderer>().enabled = true; // Show rainbow emblem on player 
            GetComponent<SpriteRenderer>().enabled = false; 
            GetComponent<BoxCollider2D>().enabled = false; 
            startTimer = true; // Start the timer
        }
    }
}