using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody physic;

    public float speed;


    void Start()
    {
        physic = GetComponent<Rigidbody>();
        transform.position = new Vector3(0f, 0f, -2.4f);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        physic.velocity = movement * speed;

        float clampedX = Mathf.Clamp(physic.position.x, -3.5f, 3.5f);
        float clampedZ = Mathf.Clamp(physic.position.z, -3.5f, 1.3f);

        physic.position = new Vector3(clampedX, 0, clampedZ);

        physic.rotation = Quaternion.Euler(0, 0, physic.velocity.x * -3);

    }             
}


