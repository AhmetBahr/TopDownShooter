using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Horizontal_Shotter : MonoBehaviour
{
    [SerializeField] private float ShootTime;


    [Header("Position")]
    [SerializeField] private Transform firePoint1;

    [Header("Prefs")]
    [SerializeField] private GameObject bulletToFire;



    private void Update()
    {
        Controller();


    }

    private void Controller()
    {
        ShootTime -= Time.deltaTime;

        if (ShootTime <= 0)
        {
            shoot();
        }

    }

    private void shoot()
    {
        Instantiate(bulletToFire, firePoint1.position, transform.rotation);


        ShootTime = 2; // Zamani degister
    }
}
