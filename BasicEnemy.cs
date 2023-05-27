using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    [Header("Main Data")]
    [SerializeField] private float health;
    [SerializeField] private float speed;

    [Header("Distance")]
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float retreatDistance;


    [Header("Dazed Time")]
    [SerializeField] private float startDazedTime;
    private float dazedTime;

    [Header("Shoots")]
    private float timeBtwShots;
    [SerializeField] public float startTimeBtwShots;


    [Header("Shoots")]
    [SerializeField] private GameObject projectile;
    private Transform playerPosition;

    private Animator anim;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    
    }

    private void Update()
    {
        dazedTimee();
        HealthControl();
        Moving();
        Shooting();
    }



    public void TakeDamage(float damage)
    {
        //hurt sound
        //blood effect
        health -= damage;
        Debug.Log("Damage Taken!");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "YellowBullet")
        {
            //  Destroy(collision.gameObject);
            TakeDamage(10);
    
        }

    }

    private void HealthControl()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void dazedTimee()
    {
        if (dazedTime <= 0)
        {
            speed = 3;
        }
        else
        {
            Debug.Log("Dazed");
            speed = 0;
            dazedTime = Time.deltaTime;
        }
      
    }

    private void Moving()
    {
        if(Vector2.Distance(transform.position,playerPosition.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position,speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position,playerPosition.position) < stoppingDistance && Vector2.Distance(transform.position,playerPosition.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position,playerPosition.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, -speed * Time.deltaTime);
        }
    }


    private void Shooting()
    {
        if(timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
