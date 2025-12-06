using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public Enemymovement Enemymovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Enemymovement.player = collision.gameObject;
            Enemymovement.seenPlayer = true;
        }
    }
}
