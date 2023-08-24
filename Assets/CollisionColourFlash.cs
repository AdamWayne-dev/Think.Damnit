using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CollisionColourFlash : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("GoodGuy"))
        {
            StartCoroutine(FlashGreen());
        }

        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(FlashRed());
        }
    }

    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;

    }

    IEnumerator FlashGreen()
    {
        spriteRenderer.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
