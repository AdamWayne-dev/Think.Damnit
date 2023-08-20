using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    int amountOfEnemiesInWave;
    // Start is called before the first frame update
    void Start()
    {
        amountOfEnemiesInWave = currentWave.GetAmountOfEnemies();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i <= amountOfEnemiesInWave; i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(), currentWave.GetRandomSpawnPoint().position, Quaternion.identity, transform);
            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }
        
    }

    // Method for getting current wave

    // Method for getting how many enemies in that wave
   
}
