using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    Rigidbody physic;

    public GameObject laserBeam;

    private AudioSource audioSource;

    public int laserSpeed;
    public float fireRate;
    private float nextFireTime;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        physic = GetComponent<Rigidbody>();
        nextFireTime = 0f;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            FireLaser();
            nextFireTime = Time.time + 1f / fireRate;
            audioSource.Play();
        }
    }
    void FireLaser()
    {
        GameObject newLaser = Instantiate(laserBeam, transform.position, transform.rotation);
        physic = newLaser.GetComponent<Rigidbody>();
        physic.velocity = transform.forward * laserSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyLaser"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
