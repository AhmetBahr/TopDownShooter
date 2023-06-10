using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] private float maxHealth = 300;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float MeleeDamage;
  
    private float currentHealth;

    private float moveHori;
    private float MoveVeck;

    [Header("MeleeAttack")]
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layers;


    [Header("Object")]
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Healty hl;
    [SerializeField] private CampFire fr;

    [Header("Anim")]
    private Animator anim;

    
    private void Start()
    {
        anim = GetComponent<Animator>();
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
        moveHori = Input.GetAxisRaw("Horizontal");
        MoveVeck = Input.GetAxisRaw("Vertical");
        rb2D.velocity = new Vector2(moveHori, MoveVeck) * moveSpeed;



        if (moveHori > .1f || moveHori < -.1f)
        {
            anim.SetBool("Walk-Hori", true);
        }
        else
        {
            anim.SetBool("Walk-Hori", false);

        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("MeleeAttack", true);
        }

    }


    #endregion

    #region Attack

    public void PlayerTakeDamage(float damage)
    {
        currentHealth -= damage;
        hl.setHealth(currentHealth);
    }

    public void meleeAttack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, layers);

        foreach(Collider2D enemyGameobject in enemy)
        {
            //  Debug.Log("Hit enemy");
            enemyGameobject.GetComponent<BasicEnemy>().health -= MeleeDamage;
        }
    }

    public void endAttack()
    {
        anim.SetBool("MeleeAttack", false);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
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
