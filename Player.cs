using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float maxHealth = 300;
    [SerializeField] private float currentHealth;
 
    
    [Header("Scripts")]
    [SerializeField] private Healty hl;

    private void Start()
    {
        currentHealth = maxHealth;
        hl.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        control();
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        hl.setHealth(currentHealth);
    }


    private void control()
    {
        if( currentHealth < 0)
        {
            //anim 
            DestroyObject(gameObject);
        }


    }

}
