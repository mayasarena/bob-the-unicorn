using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevelMenu : MonoBehaviour
{
    // Load Level 2
    public void Continue() {
        SceneManager.LoadScene(2);
    }
}
