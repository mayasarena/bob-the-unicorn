using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    private float fadeTimer;
    public CanvasGroup EndOfLevelBG;
    public CanvasGroup EndOfLevelScreen;
    private bool endIsReached = false;

    void Start()
    {
        EndOfLevelScreen.blocksRaycasts = false;
        EndOfLevelScreen.alpha = 0;
        EndOfLevelBG.alpha = 0;
    }

    void Update()
    {
        if (endIsReached)
        {
            EndLevel();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") { // Check for player
            GetComponent<SpriteRenderer>().enabled = false;
            endIsReached = true;
            EndLevel();
        }
    }

    private void EndLevel()
    {
         // Fade to the game over screen
        fadeTimer += Time.deltaTime;
        EndOfLevelBG.alpha = fadeTimer / fadeDuration;

        if(fadeTimer > fadeDuration + displayImageDuration)
        {
            EndOfLevelScreen.blocksRaycasts = true;
            EndOfLevelScreen.alpha = 1; // Show the Game Over menu
        }
    }
}
