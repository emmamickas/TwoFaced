using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : LevelController
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
        if (Player.playerObject.transform.position.x < -6.9 || Player.playerObject.transform.position.x > 8.1 || Player.playerObject.transform.position.y > 6.7 || Player.playerObject.transform.position.y < -6.4)
        {
            if (Player.playerObject.transform.position.x > 3 && Player.playerObject.transform.position.x < 7.9 && Player.playerObject.transform.position.y >= 6.7)
            {
                // Level over, exiting room
                return;
            }

            PutBackInBounds(Player.playerObject);
        }

        foreach (BaseEnemy enemy in EnemyManager.enemies.Values)
        {
            if (enemy.enemyObject.transform.position.x < -6.9 || enemy.enemyObject.transform.position.x > 8.1 || enemy.enemyObject.transform.position.y > 6.7 || enemy.enemyObject.transform.position.y < -6.4)
            {
                PutBackInBounds(enemy.enemyObject);
            }
        }
    }

    public override void OpenDoor()
    {
        // Basic Wall Generic - 8" [364185] is in the way
        // Door-Exterior-Double Door-Exterior-Double [364187] needs to open

        GameObject wall = GameObject.Find("WallToOpen");

        BoxCollider2D boxCollider = wall.GetComponent<BoxCollider2D>();

        boxCollider.enabled = false;

        GameObject door = GameObject.Find("Door-Exterior-Double Door-Exterior-Double [364187]");

        door.SetActive(false);

        AmbienceManager.PlayDoorOpen();
    }

    public override void PutBackInBounds(GameObject objectToMove)
    {
        if (objectToMove.name == "Player")
        {
            objectToMove.transform.position = new Vector3(3f, -2f, 0f);
        }
        else
        {
            objectToMove.transform.position = new Vector3(4.3f, 3f, 0f);
        }
    }

    public override void SetUpLevel()
    {
        PlayerInfo.playerHealth = 100;
        startTime = Time.time;
        EnemyManager.enemyCount = 0;
        totalEnemies = 2;
        GruntSpawner enemySpawner = new GruntSpawner(totalEnemies, 1f, 2f, 0f, ObjectManager.objectManagerInstance.gruntSpawnerPrefab, ObjectManager.objectManagerInstance.gruntPrefab, SoundEffectManager.soundEffectManagerInstance.gruntSpawn);
        spawners.Add((1f, new Vector3(-4.27f, -0.18f, 0f), enemySpawner));
        storyPromptPosition = new Vector3(-1.25f, 3.4f, -5f);
        storyTextPosition = new Vector3(0.2f, 1.1f, -10.4f);
        speakerPosition = new Vector3(-2.25f, 1f, -10.2f);
            
        this.storyTexts.Add(("You must go deeper. This is just the beginning.", "TV"));
        this.storyTexts.Add(("Go to the next TV on the floor under this.", "TV"));
        this.storyTexts.Add(("Things will begin to make more sense.", "TV"));
    }
}
