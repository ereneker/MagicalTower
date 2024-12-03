using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public static EnemySpawnController Instance { get; private set; }

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Renderer arenaRenderer;
    [SerializeField] [Range(2f, 10f)] private float spawnTimer = 2f;
    [SerializeField] [Range(5f, 20f)] private float spawnInterval = 5f;
    [SerializeField] [Range(0.5f, 1f)] private float difficultyRate = 0.9f;

    private float spawnAwait;
    private Vector3 arenaBounds;

    #region MonoBehaviour

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        spawnAwait = spawnTimer;
        arenaBounds = arenaRenderer.bounds.extents * 0.9f;
    }
    

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnWave();
            spawnTimer = spawnInterval;
        }
    }

    #endregion

    #region Private Methods

    public void SpawnWave()
    {
        float xRand = Random.Range(-arenaBounds.x, arenaBounds.x);
        float zRand = Random.Range(-arenaBounds.z, arenaBounds.z);
        
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyToSpawn = enemyPrefabs[randomIndex];

        Instantiate(enemyToSpawn, new Vector3(xRand, 0f, zRand), Quaternion.identity);

        spawnInterval = Mathf.Max(spawnInterval * difficultyRate, 1f);
    }

    #endregion
}