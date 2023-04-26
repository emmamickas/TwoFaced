using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoonSpawner : BaseEnemySpawner
{
    public GoonSpawner(int maxEnemies, float minSpawnDelay, float maxSpawnDelay, float nextSpawnTime, GameObject spawnerPrefab, GameObject enemyPrefab, AudioClip spawnSound) : base(maxEnemies, minSpawnDelay, maxSpawnDelay, nextSpawnTime, spawnerPrefab, enemyPrefab, spawnSound)
    {
    }
}
