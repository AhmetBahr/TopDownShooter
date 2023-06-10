using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    [Header("Main Data")]
    [SerializeField] public float health;
   


 





    private void Start()
    {
       
        //anim = GetComponent<Animator>();

    }

    private void Update()
    {
        Controler();
    }



    public void TakeDamage(float damage)
    {
        //hurt sound
        //blood effect
        health -= damage;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            TakeDamage(20);

        }


    }

    private void Controler()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }


    }


}