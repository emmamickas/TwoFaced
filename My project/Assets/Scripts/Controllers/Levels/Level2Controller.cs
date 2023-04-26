using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : LevelController
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
        if (Player.playerObject.transform.position.x < -8.3 || Player.playerObject.transform.position.x > 8.4 || Player.playerObject.transform.position.y > 6.5 || Player.playerObject.transform.position.y < -5.6 || (Player.playerObject.transform.position.x > 2.9 && Player.playerObject.transform.position.y > 0.8))
        {
            PutBackInBounds(Player.playerObject);
        }

        foreach (BaseEnemy enemy in EnemyManager.enemies.Values)
        {
            if (enemy.enemyObject.transform.position.x < -8.3 || enemy.enemyObject.transform.position.x > 8.4 || enemy.enemyObject.transform.position.y > 6.5 || enemy.enemyObject.transform.position.y < -5.6 || (enemy.enemyObject.transform.position.x > 2.9 && enemy.enemyObject.transform.position.y > 0.8))
            {
                PutBackInBounds(enemy.enemyObject);
            }
            else if (enemy.enemyObject.transform.position.x < -2.4 && enemy.enemyObject.transform.position.y < -2.6)
            {
                PutBackInBounds(enemy.enemyObject);
            }
        }
    }

    public override void OpenDoor()
    {
        // Basic Wall Generic - 8" [369714] is in the way
        // Door-Exterior-Double Door-Exterior-Double [369717] needs to open

        GameObject wall = GameObject.Find("WallToOpen");

        BoxCollider2D boxCollider = wall.GetComponent<BoxCollider2D>();

        boxCollider.enabled = false;

        GameObject door = GameObject.Find("Door-Exterior-Double Door-Exterior-Double [369717]");

        door.SetActive(false);

        AmbienceManager.PlayDoorOpen();
    }

    public override void PutBackInBounds(GameObject objectToMove)
    {
        if (objectToMove.name == "Player")
        {
            objectToMove.transform.position = new Vector3(7f, -3.9f, 0f);
        }
        else
        {
            objectToMove.transform.position = new Vector3(1.6f, -2.4f, 0f);
        }
    }

    public override void SetUpLevel()
    {
        Debug.Log("Setting up level 2...");
        startTime = Time.time;
        EnemyManager.enemyCount = 0;
        totalEnemies = 3;
        GoonSpawner enemySpawner = new GoonSpawner(totalEnemies, 1f, 2f, 0f, ObjectManager.objectManagerInstance.goonSpawnerPrefab, ObjectManager.objectManagerInstance.goonPrefab, SoundEffectManager.soundEffectManagerInstance.goonSpawn);
        spawners.Add((1f, new Vector3(-0.58f, -3.47f, 0f), enemySpawner));
        storyPromptPosition = new Vector3(1f, 1.45f, -5f);
        storyTextPosition = new Vector3(0f, 0.9f, -10.9f);
        speakerPosition = new Vector3(-2.8f, 1f, -10.2f);

        this.storyTexts.Add(("<i>What is this? The enemies...</i>", "Player"));
        this.storyTexts.Add(("<i>They're doing some sort of... transmodification.</i>", "Player"));
        this.storyTexts.Add(("The house. It goes deeper.", "TV"));
        this.storyTexts.Add(("You must find yourself there.", "TV"));
    }
}
