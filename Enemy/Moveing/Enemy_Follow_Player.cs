using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow_Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;

    private Transform targer;

    private void Start()
    {
        targer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    private void Update()
    {
        Follow();
    }


    private void Follow()
    {
        if(Vector2.Distance(transform.position, targer.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, targer.position, speed * Time.deltaTime);
        }
    }

}
