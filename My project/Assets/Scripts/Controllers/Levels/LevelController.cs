using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelController
{
    public List<(float, Vector3, BaseEnemySpawner)> spawners = new List<(float, Vector3, BaseEnemySpawner)>();
    public Dictionary<string, BaseEnemySpawner> spawnedSpawners = new Dictionary<string, BaseEnemySpawner>();
    public float startTime = 0f;
    public int totalEnemies;
    public Vector3 storyPromptPosition;
    public Vector3 storyTextPosition;
    public bool throughDoor = false;
    public List<(string, string)> storyTexts = new List<(string, string)>();
    public Vector3 speakerPosition;

    public abstract void SetUpLevel();

    public abstract void OpenDoor();

    public abstract bool IsLevelOver();

    public abstract bool IsOkToExit();

    public abstract void BoundarySafety();

    public abstract void PutBackInBounds(GameObject objectToMove);
}
