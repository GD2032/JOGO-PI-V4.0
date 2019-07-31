using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nearFish : CountTime
{

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(-6 * Time.deltaTime, 0));
        if (transform.position.x < -10f)
            Destroy(this.gameObject);
    }
}
