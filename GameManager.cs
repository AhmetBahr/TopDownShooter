using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    Player_Main PlayerMain;

    void Start()
    {
        PlayerMain = GameObject.FindWithTag("Player").GetComponent<Player_Main>();

    }

    void Update()
    {
        
    }

    private void TextFonk()
    {



    }

}
