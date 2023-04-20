using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota;
        public float spawnInterval;
        public int spawnCount;
    }

    [System.Serializable]

    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount;
        public int spawnCount;
        public GameObject enemyPrefab;
    }

    Transform player;

    public List<Wave> waves;
    public int currentWaveCount;

    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuote = 0;
        foreach(var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuote += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuote;

    }

    void SpawnEnemies()
    {
        Instantiate(waves[0].enemyGroups[0].enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}
