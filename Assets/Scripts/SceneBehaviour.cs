using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehaviour : MonoBehaviour
{
    private void LoadScene(string sceneName)
    {
        if(sceneName == "Exit")
            Application.Quit();
        else
            SceneManager.LoadScene(sceneName);
        if(sceneName == "CreditosScene")
        {
            SceneManager.LoadScene(4);
        }
    }
}
