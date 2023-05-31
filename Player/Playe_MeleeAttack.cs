using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playe_MeleeAttack : MonoBehaviour
{
    [Header("Time")]
    private float timeBtwAttack;
    [SerializeField] private float statTimeBtwAttack;

    [Header("Damage")]
    [SerializeField] private float damage;


    [Header("Animator")]
    [SerializeField] private Animator playerAnim;

    [Header("Attack")]
    [SerializeField] private float attackRangeX;
    [SerializeField] private float attackRangeY;

    [Header("Position")]
    [SerializeField] private Transform attackPos;

    [Header("LayerMask")]
    [SerializeField] private LayerMask whatisEnemies;

    private void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
              //  camAnim.SetTrigger("shake");  Sallama güzel olabilir
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
