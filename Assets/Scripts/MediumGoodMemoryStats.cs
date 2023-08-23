using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediumGoodMemoryStats : MonoBehaviour
{
    private float ideaBarXp = 3;
    [SerializeField] Transform brainLocation;
    private float xpGiven;
    LevelStats stats;
    [SerializeField] float moveSpeed = 3f;


    private void Start()
    {
        stats = FindObjectOfType<LevelStats>();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, brainLocation.position, moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Bullet"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            xpGiven += ideaBarXp;
            stats.UpdateProgressBar(xpGiven);
            Destroy(this.gameObject);
        }
       
    }

    

}
