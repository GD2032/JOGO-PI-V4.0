using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicialButton : CountTime
{
   [SerializeField] private GameObject panel;
    private float actualTime = 10000000f;
    public static string sceneName;
    

    public void CarregarJogo(string sceneNam)
    { 
        actualTime = Tempo(-1);
        sceneName = sceneNam;
        SceneManager.LoadScene(sceneNam);
        panel.SetActive(true);
        panel.GetComponent<Animator>().SetBool("FadeOut", true);
        
    }
    public float GetActualTime()
    {
        return actualTime;
    }
}
