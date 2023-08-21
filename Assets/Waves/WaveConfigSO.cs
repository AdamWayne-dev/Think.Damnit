using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] List<GameObject> goodMemoryPrefabs;

    [SerializeField] Transform spawnPointParent;

    [SerializeField] int amountOfEnemies;
    [SerializeField] int amountOfGoodMemories;
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] float spawnDelayVariance = 0f;
    [SerializeField] float minSpawnTime = 0.3f;

    [SerializeField] float goodMemorySpawnDelay = 1f;
    [SerializeField] float goodMemorySpawnDelayVariance = 0f;
    [SerializeField] float goodMemoryminSpawnTime = 0.3f;

    public int GetAmountOfEnemies()
    {
        return amountOfEnemies;
    }

    public int GetAmountOfGoodMemories() 
    { 
        return amountOfGoodMemories; 
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public int GetGoodMemoryCount()
    {
        return goodMemoryPrefabs.Count;
    }

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefabs[Random.Range(0, 3)];
    }

    public GameObject GetGoodMemoryPrefab()
    {
        return goodMemoryPrefabs[Random.Range(0, 3)];
    }

    public Transform GetRandomSpawnPoint()
    {
        List<Transform> spawnPoints = new List<Transform>();

        foreach(Transform child in spawnPointParent)
        {
            spawnPoints.Add(child);
        }

        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(spawnDelay - spawnDelayVariance, spawnDelay + spawnDelayVariance);

        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }
    public float GetRandomGoodMemorySpawnTime()
    {
        float spawnTime = Random.Range(goodMemorySpawnDelay - goodMemorySpawnDelayVariance, goodMemorySpawnDelay + goodMemorySpawnDelayVariance);

        return Mathf.Clamp(spawnTime, goodMemoryminSpawnTime, float.MaxValue);
    }

}
