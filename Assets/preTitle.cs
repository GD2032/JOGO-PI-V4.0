using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class preTitle : MonoBehaviour
{
    [SerializeField] private GameObject fade;
    public static string sceneName;


    void Update()
    {
        if (Time.time > 1)
        {
            Instantiate(fade);
            StartCoroutine(Contador());  
        }
        IEnumerator Contador()
            {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Warning");
        }
    }
}
