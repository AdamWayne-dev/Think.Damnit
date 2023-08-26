using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] LevelStats stats;

    [SerializeField] GameObject brain;
    [SerializeField] GameObject shockwaveEffect;

    [SerializeField] GameObject gunPoint;

    [SerializeField] AudioSource laserSound;
    [SerializeField] AudioSource empSound;
    // Add fire delay
    float launchForce = 10f;

    float currentFocusValue;
    // Start is called before the first frame update
    void Start()
    {
       
        stats = FindObjectOfType<LevelStats>();
    }

    // Update is called once per frame
    void Update()
    {

        currentFocusValue = stats.GetFocusLevel();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayLaserSound();
            GameObject bullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity);



            Vector2 launchDirection = transform.up;

            float angle = Mathf.Atan2(launchDirection.y, launchDirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle + 90f);

            Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
            // Apply the launch force to the arrow
            bulletRigidBody.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
        }

        if (currentFocusValue == 100) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                empSound.volume = 0.9f;
                empSound.Play();
                GameObject shockwave = Instantiate(shockwaveEffect, brain.transform.position, Quaternion.identity);
                ShockwaveManager shockwaveManager = FindAnyObjectByType<ShockwaveManager>();
                shockwaveManager.CallShockwave();
                var clones = GameObject.FindGameObjectsWithTag("Enemy");
                foreach(var clone in clones)
                    {
                      
                        Destroy(clone, 0.3f);
                    }
                stats.ResetFocus();
                Destroy(shockwave, 1f);
           }
        }
    }
    public void PlayLaserSound()
    {
        laserSound.volume = 0.01f;
        laserSound.pitch = Random.Range(0.3f, 1f);
        laserSound.Play();
    }
    
}
