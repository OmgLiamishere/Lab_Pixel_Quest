using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemymovement : MonoBehaviour
{

    public float speed = 5;
    public Transform[] patrolPoints;
    public int patrolIndex = 0;
    public bool seenPlayer = false;
    public GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[patrolIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((seenPlayer))
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolIndex].position, speed * Time.deltaTime);

            if (transform.position == patrolPoints[patrolIndex].position)
            {
                patrolIndex++;
                if (patrolIndex >= patrolPoints.Length)
                {
                    patrolIndex = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If it touches the bullet, it updates 
        if (collision.gameObject.tag == "Bullet")
        {
            //Updates the Score 
            //Destorys the bullet
            Destroy(collision.gameObject);
            //Destorys the enemy 
            Destroy(transform.parent.gameObject);
        }
    }
}
