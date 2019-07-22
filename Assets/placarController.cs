using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class placarController : MonoBehaviour
{
    [SerializeField] private Text[] colocacoes;
    [SerializeField] private string[] localDoSave;
    // Start is called before the first frame update
    void Start()
    {
        for (int  i = 0;  i < colocacoes.Length;  i++)
        {
            colocacoes[i].text = PlayerPrefs.GetFloat(localDoSave[i]).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
