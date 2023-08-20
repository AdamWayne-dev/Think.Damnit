using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject gunPoint;

    float launchForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
           GameObject bullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity);



            Vector2 launchDirection = transform.up;

            float angle = Mathf.Atan2(launchDirection.y, launchDirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle + 90f);

            Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
            // Apply the launch force to the arrow
            bulletRigidBody.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
        }
    }
    
}
