using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] float smallMoveSpeed = 3f;
    [SerializeField] float mediumMoveSpeed = 2f;
    [SerializeField] float largeMoveSpeed = 1f;

    [SerializeField] List<GameObject> enemyPrefabs;

    [SerializeField] Transform spawnPointParent;

    [SerializeField] int amountOfEnemies;
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] float spawnDelayVariance = 0f;
    [SerializeField] float minSpawnTime = 0.3f;

    public int GetAmountOfEnemies()
    {
        return amountOfEnemies;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefabs[Random.Range(0, 3)];
    }
    
    public Transform GetRandomSpawnPoint()
    {
        List<Transform> spawnPoints = new List<Transform>();

        foreach(Transform child in spawnPointParent)
        {
            spawnPoints.Add(child);
        }

        return spawnPoints[Random.Range(0, 23)];
    }

    

    public float GetSmallMoveSpeed()
    {
        return smallMoveSpeed;
    }

    public float GetMediumMoveSpeed()
    {
        return mediumMoveSpeed; 
    }
    public float GetLargeMoveSpeed()
    {
        return largeMoveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(spawnDelay - spawnDelayVariance, spawnDelay + spawnDelayVariance);

        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }
    
}
