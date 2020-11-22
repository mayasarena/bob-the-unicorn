using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive = 1;
    public bool knockBackPlayer;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") { // Check for player
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, knockBackPlayer, gameObject.transform); // Hurt player
        }
    }
}
