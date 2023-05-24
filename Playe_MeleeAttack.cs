using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playe_MeleeAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float statTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatisEnemies;
   // public Animator camAnim;
    public Animator playerAnim;
    public float attackRangeX;
    public float attackRangeY;
    public float damage;

    private void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
              //  camAnim.SetTrigger("shake");
                playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatisEnemies);

                for(int i=0;i< enemiesToDamage.Length;i++)
                {
                    enemiesToDamage[i].GetComponent<BasicEnemy>().TakeDamage(damage);

                }
                timeBtwAttack = statTimeBtwAttack;

            }

        }
        else
        {
            timeBtwAttack -= statTimeBtwAttack;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY));
    }




}
