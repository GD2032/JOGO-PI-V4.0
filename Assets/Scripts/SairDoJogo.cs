using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SairDoJogo : MonoBehaviour
{
   
   [SerializeField]private Button exit;
    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener (() => FecharOJogo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FecharOJogo()
    {
        Application.Quit();
        print("gsdg");
    }
}
