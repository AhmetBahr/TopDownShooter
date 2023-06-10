using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow_Reteret : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float retreatDistance;


    [Header("Object")]
    private Transform player;


    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    private void Update()
    {
        Moveing();
    }


    private void Moveing()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position,player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, - speed * Time.deltaTime);
        }
    }



}
