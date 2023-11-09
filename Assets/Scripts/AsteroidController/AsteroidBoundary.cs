using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBoundary : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
        }
    }
}


