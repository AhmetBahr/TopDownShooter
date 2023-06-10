using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{


    [SerializeField] private float Bulletdamage = 20;
    [SerializeField] private float speed = 15f;

    [SerializeField] private Rigidbody2D rb;

    Player_Main ply;

    private void Start()
    {
       ply = GameObject.FindWithTag("Player").GetComponent<Player_Main>();
    }


    private void Update()
    {
        bulletMove();
        bulletDestroyer();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ply.PlayerTakeDamage(Bulletdamage);
            Destroy(gameObject);
        }


    }

    private void bulletMove()
    {
        rb.velocity = transform.right * speed;
    }

    private void bulletDestroyer()
    {
        Destroy(gameObject, 3);
    }

}
