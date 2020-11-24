using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;
    public Transform healthBar;
    public GameObject particles;
    public AudioSource hurtEnemyAudio;

    void Start()
    {
        currentHealth = maxHealth; // Set initial health
        healthBar.transform.localScale = 
            new Vector2(((float)currentHealth/(float)maxHealth), healthBar.transform.localScale.y); // Update enemy healthbar
    }

    public void HurtEnemy(int damage)
    {
        hurtEnemyAudio.Play();
        currentHealth -= damage; // Decrease health
        if (currentHealth <= 0)
        {
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject); // Destroy enemy if killed
        }
        healthBar.transform.localScale = 
            new Vector2(((float)currentHealth/(float)maxHealth), healthBar.transform.localScale.y); // Update health bar
    }

}
