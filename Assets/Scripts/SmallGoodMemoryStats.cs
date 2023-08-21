using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGoodMemoryStats : MonoBehaviour
{
    private int ideaBarXp = 2;
    [SerializeField] Transform brainLocation;

    [SerializeField] float moveSpeed = 3f;
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, brainLocation.position, moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            // Add xp gain to bar
        }
        if (collision.tag == ("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }

}