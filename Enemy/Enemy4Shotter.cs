using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Shotter : MonoBehaviour
{

    [SerializeField] private float ShootTime;


    [Header("Position")]
    [SerializeField] private Transform firePoint1;
  //  [SerializeField] private Transform firePoint2;
    //[SerializeField] private Transform firePoint3;
    //[SerializeField] private Transform firePoint4;

    [Header("Prefs")]
    [SerializeField] private GameObject bulletToFire;



    private void Update()
    {
        Controller();


    }

    private void Controller()
    {
        ShootTime -= Time.deltaTime;

        if(ShootTime <= 0)
        {
            shoot();
        }

    }

    private void shoot()
    {
        Instantiate(bulletToFire, firePoint1.position, transform.rotation);
   //     Instantiate(bulletToFire, firePoint2.position, transform.rotation);
    //    Instantiate(bulletToFire, firePoint3.position, transform.rotation);
    //    Instantiate(bulletToFire, firePoint4.position, transform.rotation);

        ShootTime = 2; // Zamani degister
    }



}
