using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyStats : MonoBehaviour
{
    private Animator anim;
    private int health;
    private int damageDone = 8;
    [SerializeField] Transform brainLocation;
    CircleCollider2D circleCollider2D;
    LevelStats stats;
    [SerializeField] float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        circleCollider2D = GetComponent<CircleCollider2D>();
        circleCollider2D.enabled = true;
        stats = FindObjectOfType<LevelStats>();
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position = Vector2.MoveTowards(transform.position, brainLocation.position, moveSpeed * Time.deltaTime);   
    }

    void TakeDamage()
    {
        health -= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Bullet"))
        {
            
            TakeDamage();
            if (health <= 0)
            {
                circleCollider2D.enabled = false;
                anim.enabled = true;
                Destroy(gameObject, 0.5f);
            }
        }

        if (collision.tag == ("Player"))
        {
            stats.UpdateProgressBar(-damageDone);
            stats.ResetFocus();
            Destroy(gameObject);
        }
    }
}
