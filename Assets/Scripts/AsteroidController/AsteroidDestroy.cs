using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsteroidDestroy : MonoBehaviour
{
    public GameObject explosion;

    private GameController updateScore;
    
    
    


    private void Start()
    {
        updateScore = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser") || other.gameObject.CompareTag("Asteroid"))
        {
            
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);

            updateScore.UpdateScoreWithText();
        }
    }




  
}
