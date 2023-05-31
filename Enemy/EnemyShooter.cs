using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    [Header("Shoots")]
    [SerializeField] private float startTimeBtwShots;
    private float timeBtwShots;


    [Header("Prefeb")]
    [SerializeField] private GameObject projectile;

    private void Start()
    {
        timeBtwShots = startTimeBtwShots;

    }

    void Update()
    {
        Shooting();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void Shooting()
    {

            if (timeBtwShots <= 0)
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
