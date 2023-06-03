using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyRandomMove : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] private float speed;
    private float waitTime;
    [SerializeField] private float startWaitTime;

    [Header("Position")]
    [SerializeField] private Transform moveSpot;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private void Start()
    {
        waitTime = startWaitTime;

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        
        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                waitTime = startWaitTime;
                randomMove();
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
    }

    private void randomMove()
    {
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

    }

}
