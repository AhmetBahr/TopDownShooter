using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PointShot : MonoBehaviour
{
    [Header("Shoot")]
    [SerializeField] private float startTimeBtwShots;
    private float timeBtwShots;

    [Header("Object")]
    [SerializeField] private GameObject projectiles;


    private void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        shot();
    }

    private void shot()
    {
        if(timeBtwShots <= 0)
        {
            Instantiate(projectiles, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }

}
