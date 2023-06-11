using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_straight_Moveing : MonoBehaviour
{
    [Header("Direction")]
    [SerializeField] private bool Direc_X;
    [SerializeField] private bool Direc_Y;

    [Header("Range")]
    [SerializeField] private Transform moveSpot;
    [SerializeField] private float min_X;
    [SerializeField] private float max_X;
    [SerializeField] private float min_Y;
    [SerializeField] private float max_Y;
    [SerializeField] private GameObject Enemy;

    [Header("Core")]
    [SerializeField] private float NewmoveTime;
    [SerializeField] private float speed;
    [SerializeField] private float startWaitTime;

    private float waitTime;

    private void Update()
    {
        Controller();
        moving();
    }


    private void Controller()
    {



    }

    private void moving()
    {
       // transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                waitTime = startWaitTime;
                
                RandomDirection();
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
    }

    private void RandomDirection()
    {
        int directionInt = Random.Range(0, 2);
      // Debug.Log(directionInt);

        if(directionInt == 0)
        {
            Moveing_Horizontal();
        }
        else if(directionInt == 1)
        {
            Moveing_Vectortal();

        }
    }

    private void Moveing_Horizontal()
    {
        moveSpot.position = new Vector2(Random.Range(min_X, max_X), Enemy.transform.position.y);

    }
    private void Moveing_Vectortal()
    {
        moveSpot.position = new Vector2(Enemy.transform.position.x, Random.Range(min_Y, max_Y));

    }


}
