using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    [SerializeField] int sceneToLoad = 1;


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
