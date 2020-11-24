using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public CanvasGroup[] cutScenes;
    private int currentScene;
    private int max;

    void Start()
    {
        // Show the first scene
        currentScene = 0;
        cutScenes[0].alpha = 1;
        for (int i = 1; i < cutScenes.Length; i++)
        {
            cutScenes[i].alpha = 0;
        }
    }

    void Update()
    {
        // Check if end of scenes is reached, start first level
        if ((currentScene >= cutScenes.Length - 1) && Input.GetKeyDown(KeyCode.Return))
        {
            PlayerPrefs.SetInt("current_level", 2);
            SceneManager.LoadScene(2);
        }

        // Otherwise go to next scene
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            cutScenes[currentScene].alpha = 0;
            cutScenes[currentScene + 1].alpha = 1;
            currentScene++;
        }
    }
}
