using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SmaugDestroy : MonoBehaviour
{
    public GameObject explosionEnemy;

    public GameController gameController;

    public bool smaugDeath;


    public void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();        
    }



  
    private void OnTriggerEnter(Collider other)
    {           
        if (other.gameObject.CompareTag("Laser") || other.gameObject.CompareTag("Enemy"))
        {
            if (gameController.smaugHealth == 1)
            {
                Instantiate(explosionEnemy, transform.position, transform.rotation);
                Destroy(other.gameObject);
                Destroy(gameObject);

                gameController.EnemyDeath();
                gameController.chancesCount += 2;
                gameController.chancesCountText.text = "Health:" + gameController.chancesCount;
                gameController.smaugHealthText.text = "";
                smaugDeath = true;
            }

            if (gameController.smaugHealth > 1)
            {
                Destroy(other.gameObject);
                gameController.smaugHealth--;
                gameController.smaugHealthText.text = "Smaug:" + gameController.smaugHealth;                
            }
        }       
    }    
}
