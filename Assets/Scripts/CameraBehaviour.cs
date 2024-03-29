﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : CountTime
{
    private float force;
    private float speedZoom;
    private bool enterZoom;
    private Vector3 target, limite;
    private Camera camera;
    private float speed;
    private float xmax = 2.3f;
    private float xmin = 0.3f;
    [SerializeField]private float ymax = 7.5f;
    [SerializeField]private float ymin = -5.22f;
    [SerializeField]
    private GameObject personagem;
    private float eixoY;
    private float percentageSpeed;
    private bool percentageSpeedEnabled;
    private bool startScene;
    void Start()
    {
        startTime = Time.time;
        percentageSpeed = 1;
        enterZoom = true;
        camera = GetComponentInChildren<Camera>();
        camera.orthographicSize = 0f;
        speed = 7;
        startScene = true;
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
    }

    void Limite()
    {
        if (transform.position.y > ymax)
        {
            transform.position = new Vector3(transform.position.x, ymax, -10);
        }
        if (transform.position.y < ymin)
        {
            transform.position = new Vector3(transform.position.x, ymin, -10);
        }
        if (transform.position.x > xmax)
        {
            transform.position = new Vector3(xmax, transform.position.y, -10);
        }
        if (transform.position.x < xmin)
        {
            transform.position = new Vector3(xmin, transform.position.y, -10);
        }
    }
    public void SetSpeed(float newSpeed)
    {
        this.speed = newSpeed;
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
}

