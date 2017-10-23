using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {

public void NewGame(string level)
    {
        Debug.LogWarning("Change to level 1");
        SceneManager.LoadScene(level);
    }

    public void ExitGame()
    {
        Debug.LogWarning("Exiting");
        Application.Quit();
    }
}
