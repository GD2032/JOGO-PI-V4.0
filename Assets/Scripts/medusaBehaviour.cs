using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medusaBehaviour : CountTime
{
    [SerializeField] float speed;
    int move = 1;
    void Start()
    {
        StartCoroutine("ChangeMoveInfinite");
    }
    void Update()
    {
        switch (move)
        {
            case 1:
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, speed);
                break;
            case 2:
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, -speed);
                break;
            default:
                GetComponent< Rigidbody2D>().velocity = new Vector2(-speed, 0);
                break;
        }
    }
    IEnumerator ChangeMoveInfinite()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            move = ChangeMove(move);
        }
        
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
    private int ChangeMove(int move) => move == 1 ? 2 : 1;
}
