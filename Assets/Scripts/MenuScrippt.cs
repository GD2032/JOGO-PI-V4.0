using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScrippt : MonoBehaviour
{
    [SerializeField] private GameObject[] botoes;
    [SerializeField] private GameObject botaoAtual, seta;
    [SerializeField] private Animator[] animators;
    [SerializeField] private Animator trocarCena; 
    private bool subir;
    private float input;
    private static float index;
    private bool cooldown;
    void Start()
    {
        botaoAtual.tag = botoes[0].tag;
        animacao();
        cooldown = true;
    }
    void Update()
    {
        input = Input.GetAxis("Vertical");
        if(input != 0 && cooldown)
        {
            subir = TesteSubir(input);
            botaoAtual.tag = Movimento(subir);
            cooldown = false;
            StartCoroutine("SetCooldown");
            animacao();
        }
        ControleBotoes();
    }
    private string Movimento(bool subir)
    {
        if(botaoAtual.tag == botoes[0].tag && subir)
        {
            index = 1;
            return botoes[botoes.Length - 1].tag;
        }
        else if(botaoAtual.tag == botoes[botoes.Length - 1].tag && !subir)
        {
            index = 0;
            return botoes[0].tag;
        }
        for(int i = 0; i < botoes.Length; i++)
        {
            if(subir)
            {
                if(botaoAtual.tag == botoes[i].tag)
                {
                    index = --i;
                    return botoes[i].tag;
                }
            }
            else
            {
                if(botaoAtual.tag == botoes[i].tag)
                {
                    index = ++i;
                    return botoes[i].tag;               
                }
            }
        }
        return botaoAtual.tag;
    }
    private bool TesteSubir(float input) => input > 0;
    private void animacao()
    {
        switch(index)
        {
            case 0:
               seta.transform.position = new Vector3(0,0); 
            break;
            case 1:
                seta.transform.position = new Vector3(0,-1.5f);
            break;
        }
    }
    IEnumerator SetCooldown()
    {
        yield return new WaitForSeconds(0.3f);
        cooldown = true;
    }
    private void ControleBotoes()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            switch(botaoAtual.tag)
            {
                case "Bjogar":
                    trocarCena.SetBool("jogarPress", true);
                    break;
                case "Bcreditos":
                    break;
                case "Bplacar":
                    break;
                case "Bsair":
                    break;
            }

        }
    }
}
