using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaBehaviour : MonoBehaviour
{
    [SerializeField] float Force;
    float speed;
    void Start()
    {
        Force = 1;
    }

    void FixedUpdate()
    {
       // speed = MathF.sin(Force);
        //transform.Translate(Vector3. * Time.deltaTime, Space.World);
    }
}
