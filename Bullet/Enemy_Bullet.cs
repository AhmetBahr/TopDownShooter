using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy_Bullet : MonoBehaviour
{


    [SerializeField] private float Bulletdamage = 20;
    [SerializeField] private float speed = 15f;

    [SerializeField] private Rigidbody2D rb;



    [SerializeField] private GameObject attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layers;

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


        if (collision.tag == "MyShield")
        {
            Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, layers);

            foreach (Collider2D enemyGameobject in enemy)
            {
                Destroy(gameObject);
                Debug.Log("Shield damage");
            }

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


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);

    }
}
