using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemySpawner
{
    public GameObject spawnerPrefab;
    public GameObject enemyPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 2f;
    public float nextSpawnTime = 0f;
    public float lastSpawnTime = 0f;
    public bool isSpawned = false;
    public int maxEnemies;
    public AudioClip spawnSound;

    public BaseEnemySpawner(int maxEnemies, float minSpawnDelay, float maxSpawnDelay, float nextSpawnTime, GameObject spawnerPrefab, GameObject enemyPrefab, AudioClip spawnSound)
    {
        this.maxEnemies = maxEnemies;
        this.spawnerPrefab = spawnerPrefab;
        this.enemyPrefab = enemyPrefab;
        this.minSpawnDelay = minSpawnDelay;
        this.maxSpawnDelay = maxSpawnDelay;
        this.lastSpawnTime = Time.time;
        this.nextSpawnTime = this.lastSpawnTime + nextSpawnTime;
        this.isSpawned = false;
        this.spawnSound = spawnSound;
    }
}
