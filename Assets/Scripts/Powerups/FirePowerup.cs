using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePowerup : MonoBehaviour
{
    public float fireTime;
    private float timer;
    private bool startTimer = false;
    public GameObject fireEmblem;
    public GameObject player;
    private AudioSource collectionAudio;

    void Start()
    {
        timer = fireTime;
        startTimer = false;
        fireEmblem.GetComponent<SpriteRenderer>().enabled = false; // Hide emblem
        GetComponent<SpriteRenderer>().enabled = true; // Show powerup
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
                player.GetComponent<PlayerController>().hasFire = false; // Remove fire ability
                fireEmblem.GetComponent<SpriteRenderer>().enabled = false; // Remove fire emblem from player
                Destroy(gameObject); // Destroy the game object only when time is up
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) { 
        if (other.gameObject.tag == "Player") // When player collects powerup, show the fire emblem and give ability to shoot fire
        { 
            collectionAudio.Play();
            other.GetComponent<PlayerController>().hasFire = true;
            fireEmblem.GetComponent<SpriteRenderer>().enabled = true; 
            GetComponent<SpriteRenderer>().enabled = false; 
            GetComponent<BoxCollider2D>().enabled = false; 
            startTimer = true; // Start the timer
        }
    }
}