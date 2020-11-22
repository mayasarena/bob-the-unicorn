using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public CanvasGroup pauseMenu;
    private int playerHealth;
    public HealthManager healthManager;

    void Start()
    {
        pauseMenu.blocksRaycasts = false;
        pauseMenu.alpha = 0;
    }

    void Update()
    {
        // Check if player ever presses Escape button, initiate the escape menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerHealth = healthManager.currentHealth;
            pauseMenu.alpha = 1;
            pauseMenu.blocksRaycasts = true;
        }
    }

    // Continue the game if the player presses continue
    public void Continue() {
        pauseMenu.alpha = 0;
        pauseMenu.blocksRaycasts = false;
        healthManager.currentHealth = playerHealth;
    }

    // Exit the game
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
