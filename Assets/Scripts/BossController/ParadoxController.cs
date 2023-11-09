using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParadoxController : MonoBehaviour
{
    Rigidbody physic;



    public float moveSpeed = 2f;
    public float initialZ = 7.6f;
    public float stopZ = 4.5f;



    private bool movingForward = true;

    void Start()
    {
        physic = GetComponent<Rigidbody>();
        physic.position = new Vector3(0f, 0f, initialZ);
    }

    void Update()
    {
        if (!GameManager.Instance.GameOver)
        {
            if (movingForward)
            {
                float step = moveSpeed * Time.deltaTime;
                physic.position = Vector3.MoveTowards(physic.position, new Vector3(0f, 0f, stopZ), step);

                if (physic.position.z <= stopZ)
                {
                    movingForward = false;
                }
            }
            else
            {
                Vector3 movement = new Vector3(Mathf.Sin(Time.time) * moveSpeed, 0, 0);

                float clampedX = Mathf.Clamp(physic.position.x, -3.5f, 3.5f);

                physic.position = new Vector3(clampedX, 0f, physic.position.z);
                physic.velocity = movement;
            }
        }
    }
}
