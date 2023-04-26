using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManagerInstance;
    public static bool playingGame = false;

    public Dictionary<int, LevelController> levels = new Dictionary<int, LevelController>();

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        levelManagerInstance = this;
        levels.Add(1, new Level1Controller());
        levels.Add(2, new Level2Controller());
        levels.Add(3, new Level3Controller());
        levels.Add(4, new Level4Controller());
        levels.Add(5, new Level5Controller());
    }

    public void SpawnSpawner(int i)
    {
        if (levels[GameManager.level].spawners[i].Item1 + levels[GameManager.level].startTime <= Time.time && !levels[GameManager.level].spawners[i].Item3.isSpawned) // Time for spawner to be instantiated
        {
            Vector3 spawnPos = levels[GameManager.level].spawners[i].Item2;
            GameObject newSpawnerObject = Instantiate(levels[GameManager.level].spawners[i].Item3.spawnerPrefab, spawnPos, Quaternion.identity);

            newSpawnerObject.name = newSpawnerObject.name + i.ToString();

            levels[GameManager.level].spawnedSpawners.Add(newSpawnerObject.name, levels[GameManager.level].spawners[i].Item3);

            levels[GameManager.level].spawners[i].Item3.isSpawned = true;

            Debug.Log("Spawned spawner at " + spawnPos.ToString());
        }
    }

    void Update()
    {
        // Debug.Log("Level is " + GameManager.level.ToString() + "? " + "Oh, and also, levels[GameManager.level].spawners.Count is " + levels[GameManager.level].spawners.Count.ToString());

        if (!playingGame)
        {
            return;
        }

        for (int i = 0; i < levels[GameManager.level].spawners.Count; i++)
        {
            if (levels[GameManager.level].spawners[i].Item1 + levels[GameManager.level].startTime <= Time.time && !levels[GameManager.level].spawners[i].Item3.isSpawned) // Time for spawner to be instantiated
            {
                SpawnSpawner(i);
            }
        }

        levels[GameManager.level].BoundarySafety();

        if (LevelManager.levelManagerInstance.CheckCurrentLevelOver()) // If current level needs to change
        {
            GameManager.ChangeLevel();
        }
    }

    public bool CheckCurrentLevelOver()
    {
        return this.levels[GameManager.level].IsLevelOver();
    }
}
