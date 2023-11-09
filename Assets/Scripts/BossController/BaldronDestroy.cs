using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BaldronDestroy : MonoBehaviour
{
    public GameObject explosionEnemy;

    public GameController gameController;

    public bool baldronDeath;


    public void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();        
    }



  
    private void OnTriggerEnter(Collider other)
    {          
        if (other.gameObject.CompareTag("Laser") || other.gameObject.CompareTag("Enemy"))
        {
            if (gameController.baldronHealth == 1)
            {
                Instantiate(explosionEnemy, transform.position, transform.rotation);
                Destroy(other.gameObject);
                Destroy(gameObject);

                gameController.EnemyDeath();
                gameController.chancesCount++;
                gameController.chancesCountText.text = "Health:" + gameController.chancesCount;
                baldronDeath = true;
                gameController.baldronHealthText.text = "";
            }

            if (gameController.baldronHealth > 1)
            {


                Destroy(other.gameObject);
                gameController.baldronHealth--;
                gameController.baldronHealthText.text = "Baldron:" + gameController.baldronHealth;               
            }
        }        
    }   
}
