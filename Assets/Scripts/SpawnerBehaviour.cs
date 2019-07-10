
using Assets.Scripts;
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : CountTime
{
    private int sorteio;
    [SerializeField] private GameObject[] lixos;
    [SerializeField] private GameObject[] garrafas;
    [SerializeField] private GameObject[] aguasVivas;

    void Start()
    {
        Invoker();
    }
    void SpawnObstaculos()
    {
        CancelInvoke();
        sorteio = Random.Range(0, 3);
        Vector2 position = new Vector2(14, Random.Range(5.7f, -6.89f));
        Instantiate(lixos[sorteio], position, Quaternion.identity);
    }
    void SpawnGarrafas()
    {
        sorteio = Random.Range(0, 2);
        Vector2 position = new Vector2(14, Random.Range(5.7f, -6.89f));
        Instantiate(garrafas[sorteio], position, Quaternion.identity);
    }
    void AguaVivaSpawn()
    {
        sorteio = Random.Range(0, 4);
        Vector2 position = new Vector2(14, Random.Range(5.7f, -6.89f));
        Instantiate(aguasVivas[sorteio], position, Quaternion.identity);
    }
    public void Invoker()
    {
        InvokeRepeating("SpawnGarrafas", 14f, 1.5f);
        InvokeRepeating("SpawnObstaculos", 8f, 1.5f);
        InvokeRepeating("AguaVivaSpawn", 10f, 1.5f);
        InvokeRepeating("SpawnObstaculos", 12f, 1.5f);
    }
}
