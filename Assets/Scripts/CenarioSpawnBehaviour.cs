using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioSpawnBehaviour : MonoBehaviour
{
    private int sorteio;    
    [SerializeField] private GameObject mar;
    [SerializeField] private GameObject[] fish;
    [SerializeField] private GameObject[] algas;
    [SerializeField] private GameObject[] Conchas;
    [SerializeField] private GameObject areia;
    [SerializeField] private GameObject ceu;
    void Start()
    {
        invoke();
    }

    void Update()
    {
        
    }
    void SeaSpawn()
    {
        Instantiate(mar, new Vector2(14, 2), Quaternion.identity);
    }
    void CeuSpawn()
    {
        Instantiate(ceu, new Vector2(14, 11.5f), Quaternion.identity);
    }
    void BigFishSpawn()
    {
        sorteio = Random.Range(0, 4);
        Vector2 position = new Vector2(10, Random.Range(5.7f, -9f));
        Instantiate(fish[sorteio], position, Quaternion.identity);
        Instantiate(algas[3], new Vector2(10f, -9f), Quaternion.identity);
    }
    void CoraisSpawn()
    {
        sorteio = Random.Range(0, 7);
        Vector2 position = new Vector2(10f, -9f);
        Instantiate(algas[sorteio], position, Quaternion.identity);
    }
    void CoralVerdeSpawn()
    {
        Vector2 position = new Vector2(10f, -8.5f);
        Instantiate(algas[5], position, Quaternion.identity);
        Instantiate(algas[5], new Vector2(14f, -9.7f), Quaternion.identity);
    }
    void ConchaSpawn()
    {
        sorteio = Random.Range(0, 2);
        Vector2 position = new Vector2(10f, -9.7f);
        Instantiate(Conchas[sorteio], position, Quaternion.identity);
    }
    void Sand()
    {
        Vector2 position = new Vector2(10f, -9.7f);
        Instantiate(areia, position, Quaternion.identity);
    }
    void invoke()
    {
        InvokeRepeating("Sand", 0f, 1f);
        InvokeRepeating("BigFishSpawn", 4f, 5f);
        InvokeRepeating("SeaSpawn", 0f, 1.5f);
        InvokeRepeating("CeuSpawn", 0f, 1f);
        InvokeRepeating("CoraisSpawn", 0f, 0.5f);
        InvokeRepeating("CoralVerdeSpawn", 1.25f, 2.5f);
        InvokeRepeating("ConchaSpawn", 1.4f, 2.5f);
    }
   
}
