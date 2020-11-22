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

    void Start()
    {
        timer = fireTime;
        startTimer = false;
        fireEmblem.GetComponent<SpriteRenderer>().enabled = false; 
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
                player.GetComponent<PlayerController>().hasFire = false;
                fireEmblem.GetComponent<SpriteRenderer>().enabled = false; 
                Destroy(gameObject); // Destroy the game object
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) { 
        if (other.gameObject.tag == "Player") 
        { 
            other.GetComponent<PlayerController>().hasFire = true;
            fireEmblem.GetComponent<SpriteRenderer>().enabled = true; 
            GetComponent<SpriteRenderer>().enabled = false; 
            GetComponent<BoxCollider2D>().enabled = false; 
            startTimer = true; // Start the timer
        }
    }
}