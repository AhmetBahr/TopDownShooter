using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_Pot : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] private float healFloat;

    Player_Main PlayerMain;

    private void Start()
    {
        PlayerMain = GameObject.FindWithTag("Player").GetComponent<Player_Main>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (PlayerMain.currentHealth != PlayerMain.maxHealth)
            {
                PlayerMain.Player_healing(healFloat);
                //sound
                //anim
                DeactiveObject();
            }
        }



    }


    private void DeactiveObject() 
    {
        gameObject.SetActive(false);
    }


}
