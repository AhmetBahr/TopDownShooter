using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{

    [Header("Spride")]
    [SerializeField] private Sprite[] spriteRender;

    public void On()
    {
        GetComponent<SpriteRenderer>().sprite = spriteRender[0];
    }

    public void Off()
    {
        GetComponent<SpriteRenderer>().sprite = spriteRender[1];
    }


}
