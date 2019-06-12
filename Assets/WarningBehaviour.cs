using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarningBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject fade;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= 5)
        {
            Instantiate(fade);
            if (Time.time >= 6)
            {
                SceneManager.LoadScene("Titlescreen");
            }
        }
    }
}
