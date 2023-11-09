using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDestroy : MonoBehaviour
{
    public GameObject explosionPlayer;
    public GameObject playerShip;

    private GameController gameController;

    public bool isRestart = false; 
    

    private void Start()
    {      
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    public void Update()
    {
        if(isRestart == true)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("R");
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Asteroid"))
            {
                if(gameController.chancesCount == 1)
                {
                    Instantiate(explosionPlayer, transform.position, transform.rotation);
                    Destroy(other.gameObject);
                    Destroy(gameObject);


                    gameController.GameOver();

                    gameController.chancesCount--;
                    gameController.chancesCountText.text = "Health:" + gameController.chancesCount;

                    gameController.QuitGame();

                    gameController.RestartGame();

                    GameManager.Instance.SetGameOver(true);
                }
                if(gameController.chancesCount > 1)
                {                       
                    Destroy(other.gameObject);
                    Instantiate(explosionPlayer, transform.position, transform.rotation);
                    gameController.chancesCount--;
                    gameController.chancesCountText.text = "Health:" + gameController.chancesCount;
                }              
            }                                            
    }        
}
