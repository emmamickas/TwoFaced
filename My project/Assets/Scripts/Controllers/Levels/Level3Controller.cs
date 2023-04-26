using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Controller : LevelController
{
    public override bool IsLevelOver()
    {
        if (EnemyManager.enemiesKilled >= this.totalEnemies && StoryBehaviors.levelCompletion.ContainsKey(GameManager.level) && StoryBehaviors.levelCompletion[GameManager.level])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override bool IsOkToExit()
    {
        if (EnemyManager.enemiesKilled >= this.totalEnemies)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void BoundarySafety()
    {
        if (Player.playerObject.transform.position.x < -4 || Player.playerObject.transform.position.x > 5.4 || Player.playerObject.transform.position.y > 4.6 || Player.playerObject.transform.position.y < -4.5 || (Player.playerObject.transform.position.x > 1.1 && Player.playerObject.transform.position.y < -1.5))
        {
            PutBackInBounds(Player.playerObject);
        }

        foreach (BaseEnemy enemy in EnemyManager.enemies.Values)
        {
            if (enemy.enemyObject.transform.position.x < -4 || enemy.enemyObject.transform.position.x > 5.4 || enemy.enemyObject.transform.position.y > 4.6 || enemy.enemyObject.transform.position.y < -4.5 || (enemy.enemyObject.transform.position.x > 1.1 && enemy.enemyObject.transform.position.y < -1.5))
            {
                PutBackInBounds(enemy.enemyObject);
            }
            else if (enemy.enemyObject.transform.position.x < -1.6 && enemy.enemyObject.transform.position.y > 1.5)
            {
                PutBackInBounds(enemy.enemyObject);
            }
        }
    }

    public override void OpenDoor()
    {
        // Basic Wall Generic - 8" [369011] is in the way
        // Door-Exterior-Double Door-Exterior-Double [374010] needs to open

        GameObject wall = GameObject.Find("WallToOpen");

        BoxCollider2D boxCollider = wall.GetComponent<BoxCollider2D>();

        boxCollider.enabled = false;

        GameObject door = GameObject.Find("Door-Exterior-Double Door-Exterior-Double [374010]");

        door.SetActive(false);

        AmbienceManager.PlayDoorOpen();
    }

    public override void PutBackInBounds(GameObject objectToMove)
    {
        if (objectToMove.name == "Player")
        {
            objectToMove.transform.position = new Vector3(4.3f, 3.4f, 0f);
        }
        else
        {
            objectToMove.transform.position = new Vector3(-0.4f, -0.2f, 0f);
        }
    }

    public override void SetUpLevel()
    {
        Debug.Log("Setting up level 3...");
        startTime = Time.time;
        EnemyManager.enemyCount = 0;
        totalEnemies = 4;
        BruteSpawner enemySpawner = new BruteSpawner(totalEnemies, 1f, 2f, 0f, ObjectManager.objectManagerInstance.bruteSpawnerPrefab, ObjectManager.objectManagerInstance.brutePrefab, SoundEffectManager.soundEffectManagerInstance.bruteSpawn);
        spawners.Add((1f, new Vector3(-2.82f, 0f, 0f), enemySpawner));
        storyPromptPosition = new Vector3(0.15f, -1.8f, -5f);
        storyTextPosition = new Vector3(0f, 1f, -8f);
        speakerPosition = new Vector3(-3.1f, 1.2f, -6.5f);

        this.storyTexts.Add(("<i>Things are becoming clearer. More human-like.</i>", "Player"));
        this.storyTexts.Add(("<i>Morphing into humanoids like me.</i>", "Player"));
        this.storyTexts.Add(("I am waiting...", "TV"));
    }
}
