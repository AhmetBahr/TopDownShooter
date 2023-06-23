using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] private bool CampFireOn;

    [Header("Spride")]
    [SerializeField] private Sprite[] spriteRender;

    Player_Main PlayerMain;

    private void Start()
    {
        PlayerMain = GameObject.FindWithTag("Player").GetComponent<Player_Main>();

    }



    private void FixedUpdate()
    {
        if (CampFireOn && PlayerMain.currentHealth <= PlayerMain.maxHealth)
        {
            PlayerMain.PlayerHeailng_PerSec();
        }
    }

    public void On()
    {
        GetComponent<SpriteRenderer>().sprite = spriteRender[0];

        CampFireOn = true;

        //Player speed boost 
        PlayerMain.runSpeed = PlayerMain.runSpeed + 3;
        PlayerMain.moveSpeed = PlayerMain.moveSpeed + 3;

        

    }

    public void Off()
    {
        GetComponent<SpriteRenderer>().sprite = spriteRender[1];
        CampFireOn = false;

        PlayerMain.runSpeed = PlayerMain.runSpeed - 3;
        PlayerMain.moveSpeed = PlayerMain.moveSpeed - 3;
    }


}
