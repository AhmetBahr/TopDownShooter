using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_DeathShotter : MonoBehaviour
{
    [SerializeField] private GameObject thisEnemy;
    private float currentheal;
    
        
    [Header("Position")]
    [SerializeField] private Transform firePoint1;


    [Header("Prefs")]
    [SerializeField] private GameObject bulletToFire;




    private void Update()
    {
        currentheal = thisEnemy.GetComponent<Enemy_Health>().health;


        if(currentheal <= 0)
        {
            shoot();
        }
    }

    private void shoot()
    {
        Instantiate(bulletToFire, firePoint1.position, transform.rotation);


    }
}
