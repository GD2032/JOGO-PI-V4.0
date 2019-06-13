﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lixos : CountTime
{

    private enum obstaculos{sacola, aguaViva};
    [SerializeField] private obstaculos type;
    private GameObject objetos;
    private Animator anim;
    
    void Start()
    {
        Destroy(this.gameObject, 8);
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 6);
    }
    void OnTriggerEnter2D(Collider2D colapse)
    {
        if (colapse.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
