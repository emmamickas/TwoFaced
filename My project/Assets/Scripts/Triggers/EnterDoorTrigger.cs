using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoorTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            //Debug.Log("Player has entered door area");
        }

        if (collision.name == "Player" && LevelManager.levelManagerInstance.levels[GameManager.level].IsOkToExit())
        {
            if (StoryBehaviors.levelCompletion.ContainsKey(GameManager.level))
            {
                StoryBehaviors.levelCompletion[GameManager.level] = true;
            }
            else
            {
                StoryBehaviors.levelCompletion.Add(GameManager.level, true);
            }
        }
        else
        {
            Debug.Log("Player cannot exit yet!");
        }
    }
}
