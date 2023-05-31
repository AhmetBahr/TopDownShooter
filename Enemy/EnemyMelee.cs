using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] private float damage;


    //[SerializeField] GameObject plyer;

    Player ply;

    private void Start()
    {
        ply = GameObject.FindWithTag("Player").GetComponent<Player>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            ply.PlayerTakeDamage(damage);
        }
        
    }




}
