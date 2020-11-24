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
    public AudioSource endOfLevelAudio;
    public int nextLevelIndex; // For player prefs

    void Start()
    {
        // Make sure canvas groups are in their proper states
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
        if (other.gameObject.tag == "Player") { 
            PlayerPrefs.SetInt("current_level", nextLevelIndex); // Set the player prefs so progress is saved
            endOfLevelAudio.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
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
