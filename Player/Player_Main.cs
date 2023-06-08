using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] private float maxHealth = 300;
    [SerializeField] private float currentHealth;
    [SerializeField] private float moveSpeed;



    [Header("Object")]
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Healty hl;
    [SerializeField] private CampFire fr;

    
    private void Start()
    {
        currentHealth = maxHealth;
        hl.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        control();
        playerMovement();
    }


    private void control()
    {
        if (currentHealth < 0)
        {
            //anim 
            DestroyObject(gameObject);
        }


    }



    #region Movement
    private void playerMovement()
    {
        rb2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

    }

   
    #endregion

    #region Attack

    public void PlayerTakeDamage(float damage)
    {
        currentHealth -= damage;
        hl.setHealth(currentHealth);
    }



    #endregion

    #region Collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            Debug.Log("Girdi");

            fr.On();

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            Debug.Log("Çýktý");

            fr.Off();


        }
    }

    #endregion

}
