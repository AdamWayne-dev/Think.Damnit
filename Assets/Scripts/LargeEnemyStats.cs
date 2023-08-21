using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    private int health;
    [SerializeField] Transform brainLocation;

    [SerializeField] float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
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
                Destroy(gameObject);
            }
        }
    }
}
