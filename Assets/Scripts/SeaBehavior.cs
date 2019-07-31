using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaBehavior : CountTime
{
    private float mountainSpeed,seaSpeed,predioSpeed, areiaSpeed;
    private void Start()
    {
        seaSpeed = 6;
        mountainSpeed = 2;
        predioSpeed = 4;
        areiaSpeed = 6;
    }
    void Update()
    {
        switch (gameObject.tag)
        {
            case "Mountain":
                transform.Translate(new Vector3(-mountainSpeed * Time.deltaTime, 0f));
                break;
            case "Sea":
                transform.Translate(new Vector3(-seaSpeed * Time.deltaTime, 0f));
                break;
            case "Predios":
                transform.Translate(new Vector3(-predioSpeed * Time.deltaTime, 0f));
                break;
            case "Areia":
                transform.Translate(new Vector3(-areiaSpeed * Time.deltaTime, 0f));
                break;
        }
        if(transform.position.x <= -30)
            Destroy(gameObject);
    }
}
