using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] public float health;




    private void Update()
    {
        Controler();
    }


    private void Controler()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }


    }
}
