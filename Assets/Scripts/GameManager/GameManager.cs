using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        if (EnemySpawnController.Instance != null)
        {
            EnemySpawnController.Instance.SpawnWave();
        }
    }
}
