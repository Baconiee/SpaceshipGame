using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmaugFire : MonoBehaviour
{
    Rigidbody physic;

    private AudioSource audioSource;

    public GameObject enemyLaserBeam;

    public int enemyLaserSpeed;
    public float enemyFireRate;
    private float enemyNextFireTime1;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        physic = GetComponent<Rigidbody>();
        enemyNextFireTime1 = 107f;
    }


    void Update()
    {
        if(Time.time >= enemyNextFireTime1 && !GameManager.Instance.GameOver)
        {
            FireLaser();
            enemyNextFireTime1 = Time.time + 1f / enemyFireRate;
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
