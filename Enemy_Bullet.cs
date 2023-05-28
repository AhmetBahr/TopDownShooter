using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage = 50;

    private Transform player;
    private Vector2 target;

    Player plr;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        plr  = GameObject.FindWithTag("Player").GetComponent<Player>();

        target = new Vector2(player.position.x  , player.position.y );
    
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position  , target , speed * Time.deltaTime);

        if (transform.position.x  == target.x   && transform.position.y == target.y )
        {
            DestroyerProjectiles();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DestroyerProjectiles();
            plr.TakeDamage(damage);
            Debug.Log("Oyuncu hasar aldý");
        }

    }


    void DestroyerProjectiles()
    {
        Destroy(gameObject);
    }

}
