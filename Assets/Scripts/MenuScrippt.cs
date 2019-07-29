using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScrippt : MonoBehaviour
{
    [SerializeField] private GameObject[] botoes;
    [SerializeField] private GameObject botaoAtual;
    [SerializeField] private Animator[] animators;
    [SerializeField] private Animator trocarCena;
    [SerializeField] private Image select;
    private bool subir;
    private float input;
    private static float index;
    private bool cooldown;
    void Start()
    {
        botaoAtual.tag = botoes[0].tag;
        animacao();
        cooldown = true;
        select.transform.localPosition = new Vector3(219.1f, 150.4f);
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
            index = 4;
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
               select.transform.localPosition = new Vector3(219.1f,150.4f); 
            break;
            case 1:
                select.transform.localPosition = new Vector3(219.1f,67f);
            break;
            case 2:
                select.transform.localPosition = new Vector3(219.1f, -12f);
                break;
            case 3:
                select.transform.localPosition = new Vector3(219.1f, -92f);
                break;
            case 4:
                select.transform.localPosition = new Vector3(219.1f, -174);
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
                    SceneManager.LoadScene("SampleScene");
                    break;
                case "Bopcoes":
                    break;
                case "Bcreditos":
                    SceneManager.LoadScene("CreditosScene");
                    break;
                case "Bplacar":
                    SceneManager.LoadScene("PlacarScene");
                    break;
                case "Bsair":
                    Application.Quit();
                    break;
            }

        }
    }
}
