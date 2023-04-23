using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    public GameObject[] powerupPrefab;

   

    private float spawnRange = 9.0f;
    public int enemyCount;
    private int waveNumber = 1;

    
    

    // Start is called before the first frame update
    void Start()
    {

        SpawnEnemyWave(waveNumber);
        int wichPowerup = Random.Range(0, powerupPrefab.Length);
        Instantiate(powerupPrefab[wichPowerup], GenerateSpawnPosition(), powerupPrefab[wichPowerup].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            int wichPowerup = Random.Range(0, powerupPrefab.Length);
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab[wichPowerup], GenerateSpawnPosition(), powerupPrefab[wichPowerup].transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int wichEnemy = Random.Range(0, enemiesPrefabs.Length);
            Instantiate(enemiesPrefabs[wichEnemy], GenerateSpawnPosition(), enemiesPrefabs[wichEnemy].transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float randomPosX = Random.Range(-spawnRange, spawnRange);
        float randomPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(randomPosX, 0, randomPosZ);
        return randomPos;
    }
}
