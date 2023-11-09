using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ParadoxDestroy : MonoBehaviour
{
    public GameObject explosionParadox;

    public GameController paradox;

    public bool paradoxDeath;


    public void Start()
    {
        paradox = GameObject.FindWithTag("GameController").GetComponent<GameController>();       
    }



  
    private void OnTriggerEnter(Collider other)
    {          
        if (other.gameObject.CompareTag("Laser") || other.gameObject.CompareTag("Enemy"))
        {
            if (paradox.paradoxHealth == 1)
            {
                Instantiate(explosionParadox, transform.position, transform.rotation);
                Destroy(other.gameObject);
                Destroy(gameObject);
                paradox.paradoxHealthText.text = "";

                paradox.EnemyDeath();
                GameManager.Instance.SetGameOver(true);

                
                paradoxDeath = true;

                
                paradox.FinishedTheGame();

                paradox.QuitGame();

                paradox.RestartGame();
            }

            if (paradox.paradoxHealth > 1)
            {
                Destroy(other.gameObject);
                paradox.paradoxHealth--;
                paradox.paradoxHealthText.text = "Paradox:" + paradox.paradoxHealth;                
            }
        }
        
    }
  
}
