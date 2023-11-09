using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldronFire : MonoBehaviour
{
    Rigidbody physic;

    private AudioSource audioSource;

    public GameObject enemyLaserBeam;

    public int enemyLaserSpeed;
    public float enemyFireRate;
    private float enemyNextFireTime;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        physic = GetComponent<Rigidbody>();
        enemyNextFireTime = 55f;
    }


    void Update()
    {

        if(Time.time >= enemyNextFireTime && !GameManager.Instance.GameOver)
        {
            FireLaser();
            enemyNextFireTime = Time.time + 1f / enemyFireRate;
            audioSource.Play();
        }
    }

    void FireLaser()
    {                     
        GameObject newLaser = Instantiate(enemyLaserBeam, transform.position, transform.rotation);
        physic = newLaser.GetComponent<Rigidbody>();
        physic.velocity = transform.forward * enemyLaserSpeed;        
    }
}
