using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float speed;


    [SerializeField] private float startDazedTime;
    private float dazedTime;


    private Animator anim;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if(dazedTime <= 0)
        {
            speed = 0;
        }
        else
        {
            speed = 0;
            dazedTime = Time.deltaTime;
        }



        if(health <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left*speed*Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        //hurt sound
        //blood effect
        health -= damage;
        Debug.Log("Damage Taken!");
    }


}
