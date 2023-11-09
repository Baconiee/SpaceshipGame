using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] int sceneToLoad = 2;


    public void OnTriggerEnter(Collider other)
    {       
        if (other.tag == "Player1")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
