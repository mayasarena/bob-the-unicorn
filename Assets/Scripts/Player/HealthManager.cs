using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject player;
    public HealthBar healthBar;

    // Game Over stuff
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    private float fadeTimer;
    public CanvasGroup deadBG;
    public CanvasGroup deadScreen;
    private bool playerIsDead = false;
    public GameObject particles;
    public float deathDelay = 2f;

    public CameraController cameraController;

    [HideInInspector]
    public bool isInvincible = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        deadScreen.blocksRaycasts = false;
        deadScreen.alpha = 0;
    }

    void Update()
    {
        if (playerIsDead)
        {
            Die();
        }
    }

    // Hurt the player
    public void HurtPlayer(int damage, bool knockBackPlayer, Transform enemy)
    {
        if (!isInvincible)
        {
            if (knockBackPlayer)
            {
                PlayerController playerController = player.GetComponent<PlayerController>();
                playerController.knockBackCount = playerController.knockBackLength;

                if (player.transform.position.x < enemy.position.x)
                {
                    playerController.knockFromRight = false;
                }
                else
                {
                    playerController.knockFromRight = true;
                }
            }

            currentHealth -= damage; // Decrease health
            healthBar.SetHealth(currentHealth); // Set healthbar UI
        }

        if (currentHealth <= 0) // Kill player
        {
            StartCoroutine(DeathDelay());
        }
    }

    // Heal the player
    public void HealPlayer(int heal)
    {
        if ((currentHealth + heal) >= maxHealth) // If health goes above max health, the health is equal to max health
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth); // Set healthbar UI
        }

        else 
        {
            currentHealth += heal; // Increase health
            healthBar.SetHealth(currentHealth); // Set healthbar UI
        } 
    }

    public void Die()
    {
         // Fade to the game over screen
        fadeTimer += Time.deltaTime;
        deadBG.alpha = fadeTimer / fadeDuration;

        if(fadeTimer > fadeDuration + displayImageDuration)
        {
            deadScreen.blocksRaycasts = true;
            deadScreen.alpha = 1; // Show the Game Over menu
        }
    }

    // Delay the fade for a couple of seconds
    private IEnumerator DeathDelay()
    {
        cameraController.enabled = false;
        Instantiate(particles, player.transform.position, player.transform.rotation);
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(deathDelay);
        playerIsDead = true;
    }
 }
