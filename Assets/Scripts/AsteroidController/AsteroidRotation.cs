using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    Rigidbody physic;

    [SerializeField] int rotationSpeed;

    void Start()
    {
      physic = GetComponent<Rigidbody>();

      physic.angularVelocity = Random.insideUnitSphere * rotationSpeed;
    }
}
