﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBoundary : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
        }
    }
}
