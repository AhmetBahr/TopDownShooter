using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    [Header("Shooting")]
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform BulletTransform;
    [SerializeField] private bool canFire;
    [SerializeField] public bool shieldOn;
    [SerializeField] protected bool buttonActive = false;

    [SerializeField] private float timeBetweenfireing;

    [Header("Reloading")]
    [SerializeField] private int maxAmmo;
    [SerializeField] private int currentAmmo;
    [SerializeField] private int GunAmmoLimit;

    [SerializeField] private float reloadingTime;

    [SerializeField] private bool isReloading;

    [Header("Text")]
    [SerializeField] private TMP_Text MaxAmmoText;
    [SerializeField] private TMP_Text currentText;



    private float timer;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        currentAmmo = GunAmmoLimit;
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

        if(maxAmmo <= 0)
        {
            maxAmmo = 0;
        }


        if(Input.GetMouseButton(1) && canFire && currentAmmo > 0 && !shieldOn && !isReloading)
        {
            canFire = false;
            buttonActive = true;
            currentAmmo--;
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }

        if (Input.GetMouseButtonUp(1))
        {
            buttonActive = false;
        }

        if (currentAmmo <= 0 && maxAmmo > 0 && !isReloading && !buttonActive)
        {
            StartCoroutine(reloading());
           
        }

        MaxAmmoText.text = maxAmmo.ToString();
        currentText.text = currentAmmo.ToString();
    }

    private IEnumerator reloading()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadingTime);

        if (maxAmmo < GunAmmoLimit)
        {
            currentAmmo = maxAmmo;
            maxAmmo -= maxAmmo;


        }

        if (maxAmmo >= GunAmmoLimit)
        {
            maxAmmo -= GunAmmoLimit;
            currentAmmo = GunAmmoLimit;

        }


      

        

        isReloading = false;
    }



}
