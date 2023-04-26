using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Controller : LevelController
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
        if (StoryBehaviors.levelCompletion.ContainsKey(GameManager.level) && StoryBehaviors.levelCompletion[GameManager.level])
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
        if (StoryBehaviors.levelCompletion.ContainsKey(GameManager.level))
        {
            StoryBehaviors.levelCompletion[GameManager.level] = true;
        }
    }

    public override void PutBackInBounds(GameObject objectToMove)
    {
    }

    public override void SetUpLevel()
    {
        Debug.Log("Setting up level 5...");
        startTime = Time.time;
        EnemyManager.enemyCount = 0;
        totalEnemies = 0;
        storyPromptPosition = new Vector3(0.5f, 15.07f, -1.63f);
        storyTextPosition = new Vector3(0.5f, 13.54f, -5f);
        speakerPosition = new Vector3(-1.3f, -5.4f, -5.5f);

        this.storyTexts.Add(("As the villain falls, the house crumbles and fades.", "None"));
    }
}
