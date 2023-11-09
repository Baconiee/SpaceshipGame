using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survive : MonoBehaviour
{
    public GameObject explosionPlayer;

    private GameController gameController;


    public void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyLaser"))
        {
            if (gameController.chancesCount == 1)
            {
                Instantiate(explosionPlayer, transform.position, transform.rotation);
                Destroy(other.gameObject);
                Destroy(gameObject);


                gameController.GameOver();

                gameController.QuitGame();

                gameController.RestartGame();

                GameManager.Instance.SetGameOver(true);
            }
            if (gameController.chancesCount > 1)
            {
                Destroy(other.gameObject);
                Instantiate(explosionPlayer, transform.position, transform.rotation);
                gameController.chancesCount--;
                gameController.chancesCountText.text = "Health:" + gameController.chancesCount;

            }
        }
    }
}
