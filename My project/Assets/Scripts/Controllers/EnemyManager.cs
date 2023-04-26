using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static Dictionary<string, BaseEnemy> enemies = new Dictionary<string, BaseEnemy>();
    public static int enemyCount = 0;
    public static int enemiesKilled = 0;

    private void Start()
    {
    }

    public static void RedirectEnemy(string enemyName, string direction)
    {

        switch (direction)
        {
            case "Up":
                enemies[enemyName].RedirectUp();
                break;

            case "Down":
                enemies[enemyName].RedirectDown();
                break;

            case "Left":
                enemies[enemyName].RedirectLeft();
                break;

            case "Right":
                enemies[enemyName].RedirectRight();
                break;
        }
    }
}
