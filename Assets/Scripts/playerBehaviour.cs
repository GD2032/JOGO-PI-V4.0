using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerBehaviour : CountTime
{
    [SerializeField]
    private ShowAfter appear;
    // RectTransform m_RectTransform;
    private int[] Vidas = new int[3] { 1, 1, 1 };
    [SerializeField]
    private Text pontuacao;
    private float Count;
    private GameObject sacola;
    private GameObject aguaViva;
    private GameObject camera;
    [SerializeField]
    private GameObject fundoPreto;
    [SerializeField]
    private GameObject fundoPreto2;
    private GameObject[] Coracao = new GameObject[3];
    private float contadorQte;
    private bool leftArrowEnabled;
    private bool rightArrowEnabled;
    [SerializeField] private Image bolha;
    private float contagemRegressiva;
    private float opacidadeBolha;
    [SerializeField] private Text contagemQte;

    private float animationF;
    private float animationProx;
    private float speed;
    public float opacidadee;
    public float opacidadeRA;
    public float opacidadeLA;
    private static bool movimento;
    private static float posicaoPersonagem;
    private bool instantiateQte = true;
    public AudioClip ComendoSom;
    public AudioSource Tartaruga;
    public AudioClip GameOver;
    public AudioClip Vazio;

    private float xmax = 9.43f;
    private float ymax = 9.04f;
    private float ymin;
    private GameObject laser;
    private GameObject boca;
    private float movimentoEixoX;
    private float movimentoEixoY;
    private float contador = 0;
    private float pontuacaoFood;
    private bool Qte, QteExit;
    private bool pontuacaoEnable = true;
    [SerializeField]
    private Image leftArrow;
    [SerializeField]
    private Image rightArrow;
    [SerializeField]
    private Canvas canvas;
     [SerializeField]
    private GameObject gameOver;
    void Start()
    {
        contagemRegressiva = 10;
        leftArrowEnabled = true;
        instantiateQte = true;
        startTime = Time.time;
        camera = GameObject.FindWithTag("MainCamera");
        speed = 8; 
        opacidadee = 0;
        movimento = true;
        opacidadeRA = 0;
        opacidadeLA = 0;
        opacidadeBolha = 0;
        sacola = GameObject.FindWithTag("Sacola");
        aguaViva = GameObject.FindWithTag("Obstaculo");
        Coracao[0] = GameObject.FindWithTag("C1");
        Coracao[1] = GameObject.FindWithTag("C2");
        Coracao[2] = GameObject.FindWithTag("C3");
        leftArrow.color = new Color(leftArrow.color.r, leftArrow.color.g, leftArrow.color.b, opacidadeLA);
        rightArrow.color = new Color(rightArrow.color.r, rightArrow.color.g, rightArrow.color.b, opacidadeRA);
        GetComponent<AudioSource>().clip = ComendoSom;
    }

    void Update()
    {
        bolha.color = new Color(bolha.color.r, bolha.color.g, bolha.color.b, opacidadeBolha);
        StartCoroutine(Show());
        actualTime = Tempo(startTime);
        Movimentacao();
        Limite();
        pontuacao.color = new Color(pontuacao.color.r, pontuacao.color.g, pontuacao.color.b, opacidadee);
        if (actualTime >= 6f)
        {
            if (opacidadee <= 1)
            {
                pontuacao.color = new Color(pontuacao.color.r, pontuacao.color.g, pontuacao.color.b, opacidadee);
                opacidadee += 0.1f;
            } 
            if (opacidadee >= 0.1 && contador < 1)
            {
                 startTime = Time.time;
                 actualTime = Tempo(startTime);
                 Count = Mathf.Round(actualTime);
                 pontuacao.text = Count.ToString();
                 contador++;
                   
            }    
        }
       
        if ( actualTime > animationF)
        {
            GetComponent<Animator>().SetBool("Comendo", false);
            GetComponent<Animator>().SetBool("Nadando", true);
            animationF = 0;
            animationProx = 0;
        }
        if (pontuacaoEnable)
        {
             Count = Mathf.Round(actualTime) + pontuacaoFood;
             pontuacao.text = Count.ToString();
        }
         if (Qte)
        {
            if(contagemRegressiva <= 0)
            {
                Instantiate(fundoPreto);
                StartCoroutine(contagemFadeOut());
            }
            if (instantiateQte)
            {
                InstantiateArrows();
                leftArrow.color = new Color(leftArrow.color.r, leftArrow.color.g, leftArrow.color.b, opacidadeLA);
                rightArrow.color = new Color(rightArrow.color.r, rightArrow.color.g, rightArrow.color.b, opacidadeRA);
                bolha.color = new Color(bolha.color.r, bolha.color.g, bolha.color.b, opacidadeBolha);
                //instanciar tempo
                instantiateQte = false;
                StartCoroutine("");
            }
            if (leftArrowEnabled)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    opacidadeLA = 0.5f;
                    opacidadeRA = 1.0f;
                    contadorQte++;
                    rightArrowEnabled = true;
                    leftArrowEnabled = false;
                }
            } 
            if (rightArrowEnabled)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    opacidadeRA = 0.5f;
                    opacidadeLA = 1.0f;
                    contadorQte++;
                    leftArrowEnabled = true;
                    rightArrowEnabled = false;
                }
            }
            if (contadorQte >= 20)
            {
                Qte = false;
                camera.GetComponent<CameraBehaviour>().SetExitQte(true);
            }
            leftArrow.color = new Color(leftArrow.color.r, leftArrow.color.g, leftArrow.color.b, opacidadeLA);
            rightArrow.color = new Color(rightArrow.color.r, rightArrow.color.g, rightArrow.color.b, opacidadeRA);
        }
        if (contadorQte >= 20 )
        {
           quickTimeEventExit();
            if(camera.GetComponent<CameraBehaviour>().GetCameraOrthograpicSize() == 5f)
            {
                contadorQte = 0;
            }
        }
    }

    void Movimentacao()
    {
        movimentoEixoX = Input.GetAxis("Horizontal");
        movimentoEixoY = Input.GetAxis("Vertical");
        if (movimento)
        {
            transform.Translate(Vector3.right * movimentoEixoX * speed * Time.deltaTime, Space.World);
            transform.Translate(Vector3.up * movimentoEixoY * speed * Time.deltaTime, Space.World);
        }
    }
    void Limite()
    {
        if (transform.position.x > xmax)
        {
            transform.position = new Vector3(xmax, transform.position.y);
        }
        else if (transform.position.x < -xmax)
        {
            transform.position = new Vector3(-xmax, transform.position.y);
        }
        if (transform.position.y > ymax)
        {
            transform.position = new Vector3(transform.position.x, ymax);
        }
        if (transform.position.y < -ymax)
        {
            transform.position = new Vector3(transform.position.x, -ymax);
        }
    }
    void OnTriggerEnter2D(Collider2D colapse)
    {
        GetComponent<AudioSource>().PlayOneShot(ComendoSom);
        if (colapse.tag == "Sacola")
        {
            for (int i = 0; i < 3; i++)
            {
                if (Vidas[i] == 1)
                {
                    contadorQte++;
                    Vidas[i] = 0;
                    // armazena uma referência ao SpriteRenderer no GameObject atual
                    SpriteRenderer opacidade = Coracao[i].transform.GetComponent<SpriteRenderer>();
                    // copia a propriedade da cor do SpriteRenderer
                    Color opac = opacidade.color;
                    // altera o valor alfa do opac (0 = invisível, 1 = totalmente opaco)
                    opac.a = 0.5f;
                    // altera a propriedade color do SpriteRenderer para corresponder à cópia com o valor alfa alterado
                    opacidade.color = opac;
        
                    if (Vidas[2] == 0)
                    {
                        Instantiate(fundoPreto);
                        StartCoroutine(contagemFadeOut());
                             
                    }
                    break;
                }
            }
        }
        if (colapse.tag == "Obstaculo")
        {
            pontuacaoFood += 10;
        }
        if (colapse.tag == "SacolaQte")
        {
            quickTimeEvent();
        }
    }
    public void animationEat()
    {
        GetComponent<Animator>().SetBool("Nadando", false);
        GetComponent<Animator>().SetBool("Comendo", true);
        animationProx = actualTime;
        animationF = animationProx + 0.5f;
    }
      public void quickTimeEvent()
    {
        QteExit = false;
        movimento = false;
        camera.GetComponent<CameraBehaviour>().SetSpeed(0);
        camera.GetComponent<CameraBehaviour>().SetZoomQte(true);
        Qte = true;
        camera.GetComponent<CameraBehaviour>().SetQte(true);
        pontuacaoEnable = false;   
    }
   IEnumerator contagemFadeOut()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(this.fundoPreto);
        Instantiate(this.fundoPreto2);
        // Destroy(this.gameObject);
         transform.position = new Vector3 (-9,0,0);
        StartCoroutine(TeladeGameOver());  
    }
     IEnumerator TeladeGameOver()
    {
        yield return new WaitForSeconds(0.6f);
        GetComponent<AudioSource>().PlayOneShot(GameOver);
        gameOver.SetActive(true);
        yield return new WaitForSeconds(10f);
        CarregarMenuInicial("Titlescreen");
        appear.gameObject.SetActive(false);
        Time.timeScale = 0f; 
        GetComponent<RectTransform>().anchoredPosition = new Vector2(-336.65f,-211f);
    }

    public void CarregarMenuInicial(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

     public void InstantiateArrows()
    {
        opacidadeLA = 1.0f;
        opacidadeRA = 0.5f;
        opacidadeBolha = 0.7f;
        leftArrow.color = new Color(leftArrow.color.r, leftArrow.color.g, leftArrow.color.b, opacidadeLA);
        rightArrow.color = new Color(rightArrow.color.r, rightArrow.color.g, rightArrow.color.b, opacidadeRA);
        bolha.color = new Color(bolha.color.r, bolha.color.g, bolha.color.b, opacidadeBolha);
    }
     IEnumerator Show()
     {
        yield return new WaitForSeconds(8f);
        appear.gameObject.SetActive(true);
     }
     public void quickTimeEventExit()
     {
        pontuacaoEnable = true;
        movimento = true;
        QteExit = true;
        camera.GetComponent<CameraBehaviour>().SetQte(false);
        camera.GetComponent<CameraBehaviour>().SetZoomQte(false);
        camera.GetComponent<CameraBehaviour>().SetSpeed(6);
        camera.GetComponent<CameraBehaviour>().Zoom(2f,5f,false,false);
    }
    public bool GetQte(string Função = "")
    {
        if(Função == "Exit")
        {
            return QteExit;
        }
        else
        {
            return Qte;
        }
    }
    public void SetQteExit(bool condition)
    {
       QteExit = condition;
    }
    IEnumerator ContagemQte()
    {
        new WaitForSeconds(1);
        yield return contagemRegressiva--;
        contagemQte.text = contagemRegressiva.ToString();
    }
}