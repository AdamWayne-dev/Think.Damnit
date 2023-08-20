using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyStats : MonoBehaviour
{
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {

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
                Destroy(gameObject);
            }
        }
    }
}
