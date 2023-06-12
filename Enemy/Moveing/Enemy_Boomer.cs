using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy_Boomer : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float BoombDamage;
    [SerializeField] private float waitTime;

    [Header("Bommer")]
    [SerializeField] private GameObject point;
    [SerializeField] private float radius;
    [SerializeField] private float Bombradius;
    [SerializeField] private LayerMask layers;

    private Transform targer;

    private void Start()
    {
        targer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    private void Update()
    {
        Follow();
    }


    private void Follow()
    {
        if (Vector2.Distance(transform.position, targer.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, targer.position, speed * Time.deltaTime);

            Collider2D[] enemy = Physics2D.OverlapCircleAll(point.transform.position, radius, layers);

            foreach (Collider2D enemyGameobject in enemy)
            {
                // Debug.Log("Ýçeride player");
                speed = 0;
                StartCoroutine(Boomb());
                
            }

        }
    }
    IEnumerator Boomb()
    {
        yield return new WaitForSeconds(waitTime);
        
        Collider2D[] enemy = Physics2D.OverlapCircleAll(point.transform.position, Bombradius, layers);

        foreach (Collider2D enemyGameobject in enemy)
        {
            enemyGameobject.GetComponent<Player_Main>().PlayerTakeDamage(BoombDamage);
            //Patlama animasyonu
            Destroy(gameObject);

        }
    }

  

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(point.transform.position, radius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(point.transform.position, Bombradius);

    }


}
