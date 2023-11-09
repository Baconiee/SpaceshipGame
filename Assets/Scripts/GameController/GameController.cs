using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject baldron;
    public GameObject smaug;
    public GameObject paradox;



    public Text scoreText;
    public Text gameOverText;
    public Text restartText;
    public Text quitText;
    public Text baldronInfo;   
    public Text smaugInfo;
    public Text paradoxInfo;
    public Text baldronHealthText;
    public Text smaugHealthText;
    public Text paradoxHealthText;
    public Text succesText;   
    public Text chancesCountText;

    public AsteroidSpawner spawner;

    public int score = 0;
    public int destroyedAsteroid = 0;   
    public int chancesCount = 1;
    public int maxAsteroid = 6;
    public int baldronHealth = 3;
    public int smaugHealth = 5;
    public int paradoxHealth = 10;
    public float initialZ = 7.6f;

    public bool isGameOver = false;
    public bool isRestart = false;
    public bool isQuit = false;
    public bool baldronAwake = false;
    public bool smaugAwake = false;
    public bool paradoxAwake = false;   
    public bool isEnemy;
    public bool isEnemyDeath;
    public bool isEnemyUp;
    public bool secondWave = false;


    public void Start()
    {
        spawner = GameObject.FindWithTag("AsteroidSpawner").GetComponent<AsteroidSpawner>();

        gameOverText.text = "";
        restartText.text = "";
        quitText.text = "";
        baldronInfo.text = "";
        succesText.text = "";
        smaugInfo.text = "";
        paradoxInfo.text = "";
        chancesCountText.text = "Health:1";        
        baldronHealthText.text = "";
        smaugHealthText.text = "";
        paradoxHealthText.text = "";

        chancesCount = 1;

        isEnemy = false;
        isEnemyDeath = false;

        

        StartCoroutine(EnemiesSpawn());
    }
    public void Update()
    {
        if (isRestart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
        if (isQuit)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
       
    }

    public IEnumerator EnemiesSpawn()
    {
        Vector3 bossSpawn = new Vector3(0f, 0f, initialZ);
        baldronAwake = true;
       
        if (baldronAwake)
        {
            yield return new WaitForSeconds(50);
            baldronInfo.text = "Baldron";
            yield return new WaitForSeconds(2.7f);
            Instantiate(baldron, bossSpawn, Quaternion.Euler(0, 180, 0));
            baldronInfo.text = "";
            baldronHealthText.text = "Baldron:" + baldronHealth;
            isEnemy = true;
                             
        }
        smaugAwake = true;

        if (smaugAwake)
        {
            yield return new WaitForSeconds(50);
            smaugInfo.text = "Smaug";
            yield return new WaitForSeconds(2.7f);
            Instantiate(smaug, bossSpawn, Quaternion.Euler(0, 180, 0));
            smaugInfo.text = "";
            smaugHealthText.text = "Smaug:" + smaugHealth;
            isEnemy = true;
        }

        paradoxAwake = true;

        if (paradoxAwake)
        {
            yield return new WaitForSeconds(60);
            paradoxInfo.text = "Why do i hear Boss music ?";
            yield return new WaitForSeconds(2.7f);
            Instantiate(paradox, bossSpawn, Quaternion.Euler(0, 180, 0));
            paradoxInfo.text = "";
            paradoxHealthText.text = "Paradox:" + paradoxHealth;
            isEnemy = true;
        }
    }



    public void UpdateScoreWithText()
    {
        score += 10;
        scoreText.text = "Score:" + score;
        destroyedAsteroid++;
        
        if (score == 1000)
        {
            chancesCount++;
            chancesCountText.text = "Health:" + chancesCount;
        }
    }
    public void EnemyDeath()
    {
        isEnemy = false;
        score += 50;
        scoreText.text = "Score:" + score;

        StartAsteroidSpawning();
    }

    public void StartAsteroidSpawning()
    {
        StartCoroutine(spawner.SpawnWave());
    }



    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        isGameOver = true;
    }

    public void RestartGame()
    {
        restartText.text = "Press R To Restart";
        isRestart = true;
    }

    public void QuitGame()
    {
        isQuit = true;
        quitText.text = "Press Q To Quit The Game";
    }

    public void FinishedTheGame()
    {
        succesText.text = "You Did It Great!";
    }   
}