using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public int damage = 5;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") { // Check for player
            other.GetComponent<PlayerController>().slowDown = true; // Slow down the player and damage
            FindObjectOfType<HealthManager>().HurtPlayer(damage, false, gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") { // Check for player
            other.GetComponent<PlayerController>().slowDown = false; // Player returns to normal speed on exit
        }
    }
}
