using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    [Header("Bullet")]
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform BulletTransform;
    [SerializeField] private bool canFire;
    [SerializeField] private float timeBetweenfireing;

    private float timer;

    [Header("Melee")]
    [SerializeField] private float meleeRadius;
    

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    void Update()
    {
        MouseMove();
        FireBullet();

    }

    void MouseMove()
    {
      mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);


    }


    private void FireBullet()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenfireing)
            {
                canFire = true;
                timer = 0f;
            }
        }


        if(Input.GetMouseButtonDown(1) && canFire)
        {
            canFire = false;
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }

}
