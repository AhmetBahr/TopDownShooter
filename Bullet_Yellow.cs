using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Yellow : MonoBehaviour
{
    [SerializeField] private float speed = 15f;

    [SerializeField] private Rigidbody2D rb;




    private void Update()
    {
        bulletMove();
        bulletDestroyer();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {

            Destroy(gameObject);

        }
        if (collision.tag == "Coli")
        {

            Destroy(gameObject);

        }


    }

    private void bulletMove()
    {
        rb.velocity = transform.right * speed;
    }

    private void bulletDestroyer()
    {
        Destroy(gameObject, 6);
    }
}
