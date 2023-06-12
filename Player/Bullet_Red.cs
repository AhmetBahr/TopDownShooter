using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Bullet_Red : MonoBehaviour
{

    [SerializeField] float force;
    [SerializeField] float bulletDamage;

    [SerializeField] private GameObject attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layers;

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;

    Enemy_Health enmy;

    private void Start()
    {


        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(rotation.y, rotation.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot);

        destroyerObject();
    }


    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, layers);

            foreach (Collider2D enemyGameobject in enemy)
            {
                enemyGameobject.GetComponent<Enemy_Health>().health -= bulletDamage;
            }
          //  Debug.Log("Damage enemy");
            Destroy(gameObject);
        }

        if (collision.tag == "Shield")
        {
            Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, layers);

            foreach (Collider2D enemyGameobject in enemy)
            {
               Destroy(gameObject);
                Debug.Log("Shield damage");
            }
  
        }

    }



    private void destroyerObject()
    {
        Destroy(gameObject, 5);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}
