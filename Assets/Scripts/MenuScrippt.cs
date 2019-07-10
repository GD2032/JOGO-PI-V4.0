using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScrippt : MonoBehaviour
{
    enum Botao {jogar,creditos,sair};
    private Botao botaoAtual;
    private float input;
    private bool subir;
    // Start is called before the first frame update
    void Start()
    {
        botaoAtual = jogar;
    }

    // Update is called once per frame
    void Update()
    {
        input = input.GetAxis("Vertical");
        if (input != 0)
        {
            subir = Movimento(input);
            
        }
    }
    private bool Movimento(float input) => input > 0 ? true : false;

    private Botao BotaoAtual()
    {

    }
}
