using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemySpawnerBehavior : MonoBehaviour
{
    public BaseEnemySpawner enemySpawnerScript;

    protected void Start()
    {
        this.enemySpawnerScript = LevelManager.levelManagerInstance.levels[GameManager.level].spawnedSpawners[gameObject.name];
    }

    protected void Update()
    {
        if (enemySpawnerScript.nextSpawnTime < Time.time)
        {
            this.Spawn();
        }
        //else if (EnemyManager.enemies.Count <= 0)
        //{
        //    this.Spawn();
        //}
    }

    //protected void Spawn()
    //{
    //    if (EnemyManager.enemyCount >= enemySpawnerScript.maxEnemies)
    //    {
    //        return;
    //    }

    //    Vector3 spawnPos = transform.position;
    //    GameObject newEnemyObject = Instantiate(enemySpawnerScript.enemyPrefab, spawnPos, Quaternion.identity);

    //    newEnemyObject.name = newEnemyObject.name + EnemyManager.enemyCount.ToString();

    //    SoundEffectManager.PlayEnemySpawn(this.enemySpawnerScript.spawnSound);

    //    EnemyManager.enemies.Add(newEnemyObject.name, new BaseEnemy(newEnemyObject.name, 1, 1, 10f, 1f, 0.8f, 1f, newEnemyObject, SoundEffectManager.soundEffectManagerInstance.gruntShoot));

    //    EnemyManager.enemyCount += 1;

    //    //Debug.Log("Added " + newEnemyObject.name + "to enemy dictionary and instantiated new prefab object");

    //    enemySpawnerScript.lastSpawnTime = Time.time;
    //    enemySpawnerScript.nextSpawnTime = enemySpawnerScript.lastSpawnTime + Random.Range(enemySpawnerScript.minSpawnDelay, enemySpawnerScript.maxSpawnDelay);
    //}

    protected abstract void Spawn();
}
