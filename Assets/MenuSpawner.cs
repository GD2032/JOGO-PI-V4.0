using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] peixes;
    private Vector2 position;
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
        position = new Vector2(9,Random.Range(3.77f,-3.77f));
        Destroy(Instantiate(peixes[Random.Range(0, 4)],position, Quaternion.identity), 4f);
    }
}
