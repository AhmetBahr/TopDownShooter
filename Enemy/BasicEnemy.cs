using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    [Header("Main Data")]
    [SerializeField] private float health;
    [SerializeField] private float speed;
    private float currentSpeed;

    [Header("Distance")]
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float retreatDistance;


    [Header("Dazed Time")]
    [SerializeField] private float startDazedTime;
    private float dazedTime;



    [Header("Prefeb")]
    [SerializeField] private GameObject Player;
    private Transform playerPosition;







    private void Start()
    {
        //anim = GetComponent<Animator>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        currentSpeed = speed;
    }

    private void Update()
    {
        dazedTimee();
        Controler();
        Moving();
        EnemyRotation();
    }



    public void TakeDamage(float damage)
    {
        //hurt sound
        //blood effect
        health -= damage;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "YellowBullet")
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

    private void dazedTimee()
    {
        if (dazedTime <= 0)
        {
            currentSpeed = speed;
        }
        else
        {
            Debug.Log("Dazed");
            currentSpeed = 0;
            dazedTime = Time.deltaTime;
        }
      
    }
  
    private void Moving()
    {
        if(Vector2.Distance(transform.position,playerPosition.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, currentSpeed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position,playerPosition.position) < stoppingDistance && Vector2.Distance(transform.position,playerPosition.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position,playerPosition.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, -currentSpeed * Time.deltaTime);
        }
    }


    

    private void EnemyRotation()
    {

        Vector3 plyer = Player.transform.position;
      
        Vector2 offset = new Vector2(plyer.x , plyer.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

 

}
