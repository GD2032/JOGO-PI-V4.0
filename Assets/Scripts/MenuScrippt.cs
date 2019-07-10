using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScrippt : MonoBehaviour
{
    enum Botao {jogar,creditos,sair};
    private Botao botaoAtual;
    [SerializeField] private Botao botaoArrojado;
    private float input;
    private bool subir;
    private bool enabled;
    private bool cooldown = true;
    // Start is called before the first frame update
    void Start()
    {
        botaoAtual = Botao.jogar;
    }

    // Update is called once per frame
    void Update()
    {
        enabledChange(botaoAtual,botaoArrojado);
        input = Input.GetAxis("Vertical") * Time.deltaTime;
        if (input != 0 && cooldown)
        {
            subir = Subir(input);
            enabled = enabledChange(botaoAtual,botaoArrojado);
            botaoAtual = Movimento(subir);

            Animacao();
            cooldown = false;
        }
        StartCoroutine("BaixoLegal");
    }
    private bool Subir(float input) => input > 0 ? true : false;

    private Botao Movimento(bool subir)
    {
        if(botaoAtual == Botao.jogar)
            return Botao.creditos;
        else if(botaoAtual == Botao.creditos)
            return Botao.jogar;
        else
        {
            return botaoAtual;
        }        
    }
    private void Animacao()
    {
        if(enabled)
            GetComponent<Animator>().SetBool("Enabled",true);
        else
            GetComponent<Animator>().SetBool("Enabled",false);
    }
    private bool enabledChange(Botao botaoAtual, Botao botaoArrojado)
    {
        if(botaoAtual == botaoArrojado)
            return true;
        else
            return false;
    }
    IEnumerator BaixoLegal()
    {
        yield return new WaitForSeconds(1f);
        cooldown = true;
    }
}
