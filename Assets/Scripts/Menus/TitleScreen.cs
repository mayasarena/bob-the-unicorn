using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private int level_index;

    // When Start is clicked, load the game scene
    public void LoadStart()
    { 
        level_index = PlayerPrefs.GetInt("current_level");
        if (level_index == 0)
        {
            level_index = 1;
        }
        SceneManager.LoadScene(level_index);
    }

    // Exit
    public void QuitGame()
    {
        Application.Quit();
    }
}
