using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    [SerializeField] private GameObject peixes;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("invokePeixes", 2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void invokePeixes()
    {
        Destroy(Instantiate(peixes,new Vector2(0f,0f), Quaternion.identity), 4f);
    }
}
