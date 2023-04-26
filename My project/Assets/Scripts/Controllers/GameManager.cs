using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int level;

    // Start is called before the first frame update
    void Start()
    {

        StoryBehaviors.storyBehaviorsInstance.inPromptArea = false;
        LevelManager.playingGame = true;

        if (level == 0)
        {
            SetUpLevel1();
        }
        else if (level == 1)
        {
            SetUpLevel2();
        }
        else if (level == 2)
        {
            SetUpLevel3();
        }
        else if (level == 3)
        {
            SetUpLevel4();
        }

        PlayerControl.playerHealthDisplayStatic.text = PlayerInfo.playerHealth.ToString();

        AmbienceManager.PlayElevatorMoving();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayerDied()
    {
        SceneManager.LoadScene(sceneName: "Main Menu");
    }

    public static void ChangeLevel()
    {
        Debug.Log("About to change level, current level is " + level.ToString());

        if (level == 0)
        {
            //SetUpLevel1();
            LoadLevel1();
        }
        else if (level == 1)
        {
            //SetUpLevel2();
            LoadLevel2();
        }
        else if (level == 2)
        {
            //SetUpLevel3();
            LoadLevel3();
        }
        else if (level == 3)
        {
            LoadLevel4();
        }
        else if (level == 4)
        {
            SetUpLevel5();
        }
        else if (level == 5)
        {
            LevelManager.playingGame = false;
            //SceneManager.LoadScene(sceneName: "Main Menu");
            FadeScript.fadeScriptInstance.Fade("Main Menu");
        }
    }

    public static void SetUpLevel1()
    {
        foreach ((string enemyName, BaseEnemy enemy) in EnemyManager.enemies)
        {
            GameObject enemyObject = GameObject.Find(enemyName);
            Destroy(enemyObject);
        }

        EnemyManager.enemies.Clear();

        EnemyManager.enemiesKilled = 0;

        if (StoryBehaviors.levelCompletion.ContainsKey(1))
        {
            StoryBehaviors.levelCompletion[1] = false;
        }
        else
        {
            StoryBehaviors.levelCompletion.Add(1, false);
        }

        level = 1;
        Debug.Log("Just set level to 1");
        LevelManager.levelManagerInstance.levels[1].SetUpLevel();
    }

    public static void LoadLevel1()
    {
        SceneManager.LoadScene(sceneName: "Level1");
    }

    public static void SetUpLevel2()
    {
        foreach ((string enemyName, BaseEnemy enemy) in EnemyManager.enemies)
        {
            GameObject enemyObject = GameObject.Find(enemyName);
            Destroy(enemyObject);
        }

        EnemyManager.enemies.Clear();

        EnemyManager.enemiesKilled = 0;

        if (StoryBehaviors.levelCompletion.ContainsKey(2))
        {
            StoryBehaviors.levelCompletion[2] = false;
        }
        else
        {
            StoryBehaviors.levelCompletion.Add(2, false);
        }

        level = 2;
        Debug.Log("Just set level to 2");
        LevelManager.levelManagerInstance.levels[2].SetUpLevel();
    }

    public static void LoadLevel2()
    {
        SceneManager.LoadScene(sceneName: "Level2");
    }

    public static void SetUpLevel3()
    {
        foreach ((string enemyName, BaseEnemy enemy) in EnemyManager.enemies)
        {
            GameObject enemyObject = GameObject.Find(enemyName);
            Destroy(enemyObject);
        }

        EnemyManager.enemies.Clear();

        EnemyManager.enemiesKilled = 0;

        if (StoryBehaviors.levelCompletion.ContainsKey(3))
        {
            StoryBehaviors.levelCompletion[3] = false;
        }
        else
        {
            StoryBehaviors.levelCompletion.Add(3, false);
        }

        level = 3;
        Debug.Log("Just set level to 3");
        LevelManager.levelManagerInstance.levels[3].SetUpLevel();
    }

    public static void LoadLevel3()
    {
        SceneManager.LoadScene(sceneName: "Level3");
    }

    public static void SetUpLevel4()
    {
        foreach ((string enemyName, BaseEnemy enemy) in EnemyManager.enemies)
        {
            GameObject enemyObject = GameObject.Find(enemyName);
            Destroy(enemyObject);
        }

        EnemyManager.enemies.Clear();

        EnemyManager.enemiesKilled = 0;

        if (StoryBehaviors.levelCompletion.ContainsKey(4))
        {
            StoryBehaviors.levelCompletion[4] = false;
        }
        else
        {
            StoryBehaviors.levelCompletion.Add(4, false);
        }

        level = 4;
        Debug.Log("Just set level to 4");
        LevelManager.levelManagerInstance.levels[4].SetUpLevel();
    }

    public static void LoadLevel4()
    {
        SceneManager.LoadScene(sceneName: "Level4");
    }

    public static void SetUpLevel5()
    {
        EnemyManager.enemiesKilled = 0;

        foreach ((string spawnerName, BaseEnemySpawner spawner) in LevelManager.levelManagerInstance.levels[GameManager.level].spawnedSpawners)
        {
            GameObject spawnerObject = GameObject.Find(spawnerName);
            Destroy(spawnerObject);
        }

        if (StoryBehaviors.levelCompletion.ContainsKey(5))
        {
            StoryBehaviors.levelCompletion[5] = false;
        }
        else
        {
            StoryBehaviors.levelCompletion.Add(5, false);
        }

        level = 5;
        Debug.Log("Just set level to 5");
        LevelManager.levelManagerInstance.levels[5].SetUpLevel();
    }
}
