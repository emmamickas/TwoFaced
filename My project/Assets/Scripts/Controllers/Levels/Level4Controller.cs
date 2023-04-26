using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Controller : LevelController
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

    public override void BoundarySafety()
    {
        if (Level4Behavior.level4Phase == 1)
        {
            if (Player.playerObject.transform.position.x < -1 || Player.playerObject.transform.position.x > 2 || Player.playerObject.transform.position.y < -11.5)
            {
                //PutBackInBounds(Player.playerObject);

                Player.playerObject.transform.position = new Vector3(0.5f, -11f, 0f);
            }
        }
        else if (Level4Behavior.level4Phase == 2)
        {
            if (Player.playerObject.transform.position.x < -2 || Player.playerObject.transform.position.x > 3 || Player.playerObject.transform.position.y < -8.4 || Player.playerObject.transform.position.y > -3.3)
            {
                //PutBackInBounds(Player.playerObject);

                Player.playerObject.transform.position = new Vector3(0.5f, -3.5f, 0f);
            }
        }
        else if (Level4Behavior.level4Phase == 3)
        {
            if (Player.playerObject.transform.position.x < -0.5 || Player.playerObject.transform.position.x > 1.5 || Player.playerObject.transform.position.y < -3.5)
            {
                //PutBackInBounds(Player.playerObject);

                Player.playerObject.transform.position = new Vector3(0.5f, -2.7f, 0f);
            }
        }
        else if (Level4Behavior.level4Phase == 4)
        {
            if (Player.playerObject.transform.position.x < -6.1 || Player.playerObject.transform.position.x > 9.1 || Player.playerObject.transform.position.y < 9.1 || Player.playerObject.transform.position.y > 16.2)
            {
                //PutBackInBounds(Player.playerObject);

                Player.playerObject.transform.position = new Vector3(0.5f, 9.8f, 0f);
            }
        }


        if (Player.playerObject.transform.position.y > -3.3 && Player.playerObject.transform.position.x > 1.5 && Level4Behavior.level4Phase != 4)
        {
            //PutBackInBounds(Player.playerObject);

            Player.playerObject.transform.position = new Vector3(2f, -3.5f, 0f);
        }
        else if (Player.playerObject.transform.position.y > -3.3 && Player.playerObject.transform.position.x < -0.5 && Level4Behavior.level4Phase != 4)
        {
            //PutBackInBounds(Player.playerObject);

            Player.playerObject.transform.position = new Vector3(-1f, -3.5f, 0f);
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

    public override void OpenDoor()
    {
        // Basic Wall Generic - 8" [364181] is in the way
        // Door-Exterior-Double Door-Exterior-Double [364182] needs to open at the start
        // Single-Flush 36" x 84" [370392] needs to open later

        //GameObject wall2 = GameObject.Find("WallToOpen2");

        //BoxCollider2D boxCollider2 = wall2.GetComponent<BoxCollider2D>();

        //boxCollider2.enabled = false;

        //GameObject trigger1 = GameObject.Find("UpperTriggerToOpen");

        //trigger1.SetActive(false);

        //GameObject door2 = GameObject.Find("Single-Flush 36\" x 84\" [370392]");

        //door2.SetActive(false);
    }

    public override void PutBackInBounds(GameObject objectToMove)
    {
        if (objectToMove.name == "Player")
        {
            objectToMove.transform.position = new Vector3(0.5f, -4f, 0f);
        }
    }

    public override void SetUpLevel()
    {
        Debug.Log("Setting up level 4...");
        startTime = Time.time;
        EnemyManager.enemyCount = 0;
        totalEnemies = 1;
        BossSpawner enemySpawner = new BossSpawner(totalEnemies, 5f, 8f, 5f, ObjectManager.objectManagerInstance.bossSpawnerPrefab, ObjectManager.objectManagerInstance.bossPrefab, SoundEffectManager.soundEffectManagerInstance.bossSpawn);
        spawners.Add((1f, new Vector3(0f, 13.5f, 0f), enemySpawner));
        storyPromptPosition = new Vector3(1.7f, -5.8f, -2.4f);
        storyTextPosition = new Vector3(0.5f, -5.2f, -5.5f);
        speakerPosition = new Vector3(-1.3f, -5.4f, -5.5f);

        this.storyTexts.Add(("Thou art I, I art thou. Everything has led you to yourself.", "TV"));
        this.storyTexts.Add(("Every kill. Every life.", "Villain"));
        this.storyTexts.Add(("I become you and you become me, as we are the same.", "Villain"));
        this.storyTexts.Add(("<i>The walls are... crumbling. Like they're evaporating.</i>", "Player"));

        GameObject wall1 = GameObject.Find("WallToOpen1");

        Level4Behavior.wall1 = wall1;

        BoxCollider2D boxCollider1 = wall1.GetComponent<BoxCollider2D>();

        boxCollider1.enabled = false;

        wall1.SetActive(false);

        //GameObject door1 = GameObject.Find("Door-Exterior-Double Door-Exterior-Double [364182]");

        //door1.SetActive(false);
    }
}
