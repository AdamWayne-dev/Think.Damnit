using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class SmallGoodMemoryStats : MonoBehaviour
{
    private float ideaBarXp = 3;
    private Animator anim;
    CircleCollider2D circleCollider2D;
    [SerializeField] Transform brainLocation;
    private float xpGiven;
    LevelStats stats;
    [SerializeField] float moveSpeed = 3f;


    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        circleCollider2D = GetComponent<CircleCollider2D>();
        circleCollider2D.enabled = true;
        stats = FindObjectOfType<LevelStats>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, brainLocation.position, moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Bullet"))
        {
            circleCollider2D.enabled = false;
            anim.enabled = true;
            Destroy(this.gameObject, 0.5f);
        }

        if (collision.gameObject.tag == "Player")
        {
            xpGiven += ideaBarXp;
            stats.UpdateProgressBar(xpGiven);
            stats.UpdateFocusBar(10);
            Destroy(this.gameObject);          
        }
        
    }

    
    
}
