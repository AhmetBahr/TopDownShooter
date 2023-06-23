using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Main : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] public float maxHealth = 300;
    [SerializeField] public float currentHealth;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float runSpeed;

    private float moveHorizontal;
    private float moveVertical;

    [Header("Healing Pot")]
    [SerializeField] private float HealingFloat;
    [SerializeField] private float usingTimePot;
    [SerializeField] private float healingPotCount;
    [SerializeField] private float healingPerSec;
    [SerializeField] private bool usingBool = false;


    [Header("Dash")]
    [SerializeField] private float dashingPower;
    [SerializeField] private float dashingTime;
    [SerializeField] private float dashingCooldown;
    [SerializeField] private bool canDash;

    private bool isdashing;
     

    [Header("MeleeAttack")]
    [SerializeField] private float MeleeDamage;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layers;


    [Header("Object")]
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Healty hl;
    [SerializeField] private CampFire fr;

    [Header("Text")]
    [SerializeField] private TMP_Text CurrentText;
    [SerializeField] private TMP_Text HealingPotText;
    [SerializeField] private TMP_Text HealingPerSecTextt;


    [Header("Anim")]
    private Animator anim;

    
    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        hl.SetMaxHealth(maxHealth);
        HealingPotText.text = healingPotCount.ToString();

    }

    private void Update()
    {
        control();
        playerMovement();
        HealingController();
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
        if (isdashing)
            return;

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");


        if (!Input.GetKey(KeyCode.LeftShift)) // Normal walk 
        {
            rb2D.velocity = new Vector2(moveHorizontal, moveVertical) * moveSpeed;



        }

        if (Input.GetKey(KeyCode.LeftShift)) // For Run 
        {
            rb2D.velocity = new Vector2(moveHorizontal, moveVertical) * runSpeed;

        }


        if (moveHorizontal > -.1f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        if (moveHorizontal < -.1f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        if(moveVertical > -.1f)
        {
            //Animaton
        }
        if (moveVertical < -.1f)
        {
            //Animaton
        }


        if (Input.GetKey(KeyCode.E) && canDash && moveHorizontal != 0)  // Horizontal Dash
        {
            StartCoroutine(DashHorizontal());
        }

        if (Input.GetKey(KeyCode.E) && canDash && moveVertical != 0 ) // Vertical Dash
        {   
            StartCoroutine(DashVertical());
        }



        if (moveHorizontal > .1f || moveHorizontal < -.1f)
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

    private IEnumerator DashHorizontal()
    {
        canDash = false;
        isdashing = true;
        rb2D.velocity = new Vector2(transform.localScale.x * -dashingPower, 0f);

        yield return new WaitForSeconds(dashingTime);
        isdashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    private IEnumerator DashVertical()
    {
        canDash = false;
        isdashing = true;
        rb2D.velocity = new Vector2(0f, transform.localScale.y * dashingPower);

        yield return new WaitForSeconds(dashingTime);
        isdashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
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
            enemyGameobject.GetComponent<Enemy_Health>().health -= MeleeDamage;
        }
    }

    public void endAttack()
    {
        anim.SetBool("MeleeAttack", false);
    }




    #endregion

    #region Collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
        //    Debug.Log("Girdi");

            fr.On();



        }

        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
          //  Debug.Log("Çýktý");

            fr.Off();


        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
    #endregion

    #region Heal

    public void Player_healing(float heal)
    {
        currentHealth += heal;
        hl.setHealth(currentHealth);
    }


    public void PlayerHeailng_PerSec()
    {
        currentHealth += healingPerSec;
        hl.setHealth(currentHealth);

    }


    private void HealingController()
    {
        CurrentText.text = System.Math.Round(currentHealth, 1).ToString();

        HealingPerSecTextt.text = "+" +healingPerSec.ToString();

        usingTimePot -= Time.deltaTime;

        if (usingTimePot <= 0)
            usingBool = true;

        if (Input.GetKeyDown(KeyCode.Q) && usingBool == true && healingPotCount > 0 && currentHealth != maxHealth)
        {

            //anim
            //sound
            Player_healing(HealingFloat);

            healingPotCount--;
            usingTimePot = 5;

            HealingPotText.text = healingPotCount.ToString();





        }


    }


    #endregion
}
