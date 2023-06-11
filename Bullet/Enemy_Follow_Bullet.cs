using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow_Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Bulletdamage = 50;

    private Transform player;
    private Vector2 target;

    Player_Main ply;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ply = GameObject.FindWithTag("Player").GetComponent<Player_Main>();

        target = new Vector2(player.position.x  , player.position.y );
    
    }
   
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position  , player.position , speed * Time.deltaTime);

        DestroyerProjectiles();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DestroyerProjectiles();
            ply.PlayerTakeDamage(Bulletdamage);

        }

    }


    void DestroyerProjectiles()
    {
        Destroy(gameObject,2);
    }

}
