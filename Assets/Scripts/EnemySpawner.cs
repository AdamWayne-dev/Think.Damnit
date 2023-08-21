using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WaveConfigSO currentWave;
    int amountOfEnemiesInWave;
    int amountOfGoodMemoriesInWave;
    // Start is called before the first frame update
    void Start()
    {    
        StartCoroutine(SpawnEnemyWaves());
        StartCoroutine(SpawnGoodMemoryWaves());
    }

    IEnumerator SpawnEnemyWaves() // Spawns bad memory waves
    {
        foreach(WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            amountOfEnemiesInWave = currentWave.GetAmountOfEnemies();
            
            for (int i = 0; i <= amountOfEnemiesInWave; i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(), currentWave.GetRandomSpawnPoint().position, Quaternion.identity, transform);
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
               
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        
    }

    IEnumerator SpawnGoodMemoryWaves() //Spawns good memory waves
    {
        foreach (WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            amountOfGoodMemoriesInWave = currentWave.GetAmountOfGoodMemories();

            for (int i = 0; i <= amountOfGoodMemoriesInWave; i++)
            {
                Instantiate(currentWave.GetGoodMemoryPrefab(), currentWave.GetRandomSpawnPoint().position, Quaternion.identity, transform);
                yield return new WaitForSeconds(currentWave.GetRandomGoodMemorySpawnTime());

            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }

    }

}
