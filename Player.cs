using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float maxHealth = 300;
    [SerializeField] private float currentHealth;


    [SerializeField] private Healty hl;

    private void Start()
    {
        currentHealth = maxHealth;
        hl.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            TakeDamage(20);
    }


    private void TakeDamage(float damage)
    {
        currentHealth -= damage;
        hl.setHealth(currentHealth);
    }


}
