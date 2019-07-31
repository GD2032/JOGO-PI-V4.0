using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Image[] buttons;
    private static bool pause = false;
    [SerializeField]
    private GameObject menuUI;
    private float Input;
    private bool right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Input = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Pause();
        }
        if (Input != 0 && cooldown)
        {
            right = RightTest(Input);
            TrocarBotoes(right);
        }

    }
    public void Resume() {

        menuUI.SetActive(false);
        Time.timeScale = 1f;
        pause = false; 
    }
    public void Pause() {
        menuUI.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }
    private void TrocarBotao(bool right)
    {
        switch(botaoAtual.tag)
        {
            case "Resume":
                botaoAtual.tag = TrocarBotoes(right ? 1 : 3);
                goto case anim;
            case "SoundOff":
                botaoAtual.tag = TrocarBotoes(right ? 2 : 0);
            case "SoundVolue":
                botaoAtual.tag = TrocarBotoes(right ? 3 : 1);
                break;
            case "Menu":
                botaoAtual.tag = TrocarBotoes(right ? 0 : 2);
                break;
            case anim:
                TrocarSprite();
        }
    }
    private void TrocarSprite()
    {
        switch(botaoAtual.tag)
        {
            
        }
    }
    private void RightTest(float Input) => Input > 0;
    private string TrocarBotoes(float casa) => buttons[casa].tag;
}
