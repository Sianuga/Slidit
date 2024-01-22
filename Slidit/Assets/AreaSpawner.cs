using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider2D spawnArea;

    [SerializeField] private GameObject[] enemyObjects;
    [SerializeField] private GameObject[] obstacleObjects;
    [SerializeField] private float bombSpawnDelay = 1f;
    [SerializeField] private float enemySpawnDelay = 1f;
    [SerializeField] private float enemySpawnRand = 0.2f;
    [SerializeField] private float bombSpawnRand = 0.2f;

    [SerializeField] private float enemySpawnRateMin = 2f;
    [SerializeField] private float spawnrateIncreaseDelay = 10f;
    [SerializeField] private float spawnrateIncreaseAmount = 0.1f;


    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnBombs());
        StartCoroutine(IncreaseSpawnRate());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnDelay + Random.Range(-enemySpawnRand, enemySpawnRand));
            Vector2 spawnPos = new Vector2(Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x), Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y));
            Instantiate(enemyObjects[Random.Range(0, enemyObjects.Length)], spawnPos, Quaternion.identity);
        }
    }

    private IEnumerator SpawnBombs()
    {
        while (true)
        {
            yield return new WaitForSeconds(bombSpawnDelay + Random.Range(-bombSpawnRand, bombSpawnRand));
            Vector2 spawnPos = new Vector2(Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x), Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y));
            //Check if bat is in the way
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPos, 0.5f);
            bool batInWay = false;

            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.CompareTag("Bat"))
                {
                    batInWay = true;
                }
            }

            if (!batInWay)
            {
                Instantiate(obstacleObjects[Random.Range(0, obstacleObjects.Length)], spawnPos, Quaternion.identity);
            }
            else
            {
                //Move bomb to other position

            }
            
            
        }
    }

    private IEnumerator IncreaseSpawnRate()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnrateIncreaseDelay);
            enemySpawnDelay -= spawnrateIncreaseAmount;
            bombSpawnDelay -= spawnrateIncreaseAmount;
            if (enemySpawnDelay < enemySpawnRateMin)
            {
                enemySpawnDelay = enemySpawnRateMin;
            }
        }
    }
}
