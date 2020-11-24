using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScreen : MonoBehaviour
{
    // Clear player prefs to play again
    public void PlayAgain()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
