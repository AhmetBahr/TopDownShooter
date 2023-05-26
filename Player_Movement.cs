using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{


    private Camera theCam;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletToFire;

    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float moveSpeed;
  

    private void Start()
    {
        theCam = Camera.main;
    }

    private void Update()
    {
        playerMovement();
        MousePosition();
        fireFunk();

    }
    private void playerMovement()
    {
        rb2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

    }

    private void MousePosition()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public void turnLeft()
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public void turnRight()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void fireFunk()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletToFire, firePoint.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            Debug.Log("Girdi");

        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            Debug.Log("Çýktý");

        }
    }

}
