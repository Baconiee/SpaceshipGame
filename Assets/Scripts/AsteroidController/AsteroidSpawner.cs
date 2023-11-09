using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private GameController look;

    public GameObject asteroidPrefab;

    public Vector3 spawnAreaMin;
    public Vector3 spawnAreaMax;

    private int waveMaxCount = 20; 
    private float spawnInterval = 0.4f;
    public float speed = 1.0f;
    private float continueSpawn = 2f;
    public int waveCount = 0;


    void Start()
    {
        
        look = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        StartCoroutine(SpawnWave());

    }





    public IEnumerator SpawnWave()
    {
        while (waveCount < waveMaxCount)
        {

            if (GameManager.Instance.GameOver || look.isEnemy)
            {
                break;
            }

            

            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            float spawnZ = spawnAreaMax.z;

            Vector3 spawnPosition = new Vector3(randomX, randomY, spawnZ);

            GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.Euler(90, 0, 0));
            Rigidbody physic = newAsteroid.GetComponent<Rigidbody>();

            physic.velocity = new Vector3(0, 0, -speed);
            waveCount++;


            if (waveCount == waveMaxCount)
            {
                look.destroyedAsteroid = 0;
                waveCount = 0;
                yield return new WaitForSeconds(continueSpawn);
            }

            yield return new WaitForSeconds(spawnInterval);



            ;

           
          



        }

    }








    
}
