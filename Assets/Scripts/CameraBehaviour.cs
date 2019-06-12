using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : CountTime
{

    //public float zoomSpeed ;
    //public float smoothSpeed = 30.0f;
    // public float minRange = 1.9f;
    //public float target;

    private float force;
    private float speedZoom;
    private bool enterZoom;
    private Vector3 target, limite;
    private Camera camera;
    private float size, setLimite;
    private float speed;
    private float xmax = 2.3f;
    private float xmin = 0.3f;
    private float ymax = 4.769569f;
    [SerializeField]
    private GameObject personagem;
    private float eixoY;
    private bool zoomQte;
    private float percentageSpeed;
    private bool percentageSpeedEnabled;
    private bool startScene;
    private bool qte, exitQte, exitQteLimite, limiteEnabled;
    void Start()
    {
        startTime = Time.time;
        percentageSpeed = 1;
        enterZoom = true;
        camera = GetComponentInChildren<Camera>();
        camera.orthographicSize = 0f;
        speed = 6;
        startScene = true;
        qte = false;
    }
    void Update()
    {
        actualTime = Tempo(startTime);
        if (startScene && actualTime > 3.8f)
        {
            Zoom(2f, 5f,false, false);
            if (camera.orthographicSize >= 5)
            {
                startScene = false;
            }
        }
        eixoY = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * eixoY * speed * Time.deltaTime);
        Limite();
        if (zoomQte)
        {
            Zoom(2f, 2.5f, speed: 8f);
        }
    }

    void Limite()
    {
        //////if(!qte)
        ////{
        ////   if (exitQte)
        ////   {
        ////        limiteEnabled = false;
        ////        if (exitQteLimite)
        ////        {
        ////            SetLimite();
        ////            exitQteLimite = false;
        ////        }
        ////        camera.transform.position = Vector3.MoveTowards(camera.transform.position, limite, 8f * Time.deltaTime);
        ////        if(camera.transform.position == limite)
        ////        {
        ////            print("Oche");
        ////            limiteEnabled = true;
        ////            exitQte = false;
        ////        }
        ////   }
        ////    if (limiteEnabled)
        ////    {
                if (transform.position.y > ymax)
                {
                    transform.position = new Vector3(transform.position.x, ymax, -10);
                }
                if (transform.position.y < -ymax)
                {
                    transform.position = new Vector3(transform.position.x, -ymax, -10);
                }
                if (transform.position.x > xmax)
                {
                    transform.position = new Vector3(xmax, transform.position.y, -10);
                }
                if (transform.position.x < xmin)
                {
                    transform.position = new Vector3(xmin, transform.position.y, -10);
                }
             //}
        //}
    }
    public void SetSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }
    public void SetZoomQte(bool condition)
    {
        this.zoomQte = condition;
    }
    public void Zoom(float speedZoom, float limite, bool seguirPersonagem = true, bool zoomInside = true, bool enterZoom = true, float speed = 0f)
    {
        if (seguirPersonagem)
        {
            target = new Vector3(personagem.transform.position.x,personagem.transform.position.y,-10);
            camera.transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if(camera.transform.position == target)
            {
                seguirPersonagem = false;
            }
        }
        if (enterZoom)
        { 
            if (zoomInside ? camera.orthographicSize >= limite : camera.orthographicSize <= limite)
            {
                force = speedZoom * percentageSpeed;
                if (zoomInside)
                {
                     camera.orthographicSize -= Time.deltaTime * force;
                }
                else
                {
                     camera.orthographicSize += Time.deltaTime * force;
                }
                percentageSpeed -= 0.1f * Time.deltaTime;
            }
            else
            {
                enterZoom = false;
                percentageSpeed = 1;
            }
            if (percentageSpeed <= 0)
            {
                percentageSpeed = 0.1f * Time.deltaTime;
            }
        }
    }
    public void SetQte(bool condition)
    {
        this.qte = condition;
    }
    private void SetLimite()
    {
        if (transform.position.y > ymax && transform.position.x > xmax)
        {
            setLimite = 1;
        }
        if (transform.position.y > ymax && transform.position.x < xmin)
        {
            setLimite = 2;
        }
        if (transform.position.y < -ymax && transform.position.x > xmax)
        {
            setLimite = 3;
        }
        if (transform.position.y < -ymax && transform.position.x < xmin)
        {
            setLimite = 4;
        }
        if (transform.position.y > ymax && transform.position.x < xmax && transform.position.x > xmin)
        {
            setLimite = 5;
        }
        if(transform.position.y < -ymax && transform.position.x < xmax && transform.position.x > xmin)
        {
            setLimite = 6;
        }
        if(transform.position.y < ymax && transform.position.y > -ymax && transform.position.x > xmax)
        {
            setLimite = 7;
        }
        if (transform.position.y < ymax && transform.position.y > -ymax && transform.position.x < xmin)
        {
            setLimite = 8;
        }
        switch (setLimite)
        {
            case 1:
                limite = new Vector3(xmax, ymax, -10);
                break;
            case 2:
                limite = new Vector3(xmin, ymax, -10);
                break;
            case 3:
                limite = new Vector3(xmax, -ymax, -10);
                break;
            case 4:
                limite = new Vector3(xmin, -ymax, -10);
                break;
            case 5:
                limite = new Vector3(transform.position.x, ymax, -10);
                break;
            case 6:
                limite = new Vector3(transform.position.x, -ymax, -10);
                break;
            case 7:
                limite = new Vector3(xmax, transform.position.y);
                break;
            case 8:
                limite = new Vector3(xmin, transform.position.y, -10);
                break;
            default:
                limite = transform.position;
                break;
        }

    }
    public void SetExitQte(bool condition)
    {
        this.exitQte = condition;
    }
    public float GetCameraOrthograpicSize()
    {
        return camera.orthographicSize;
    }
}

