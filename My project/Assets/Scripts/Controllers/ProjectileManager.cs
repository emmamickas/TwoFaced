using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static Dictionary<string, EnemyProjectile> enemyProjectiles = new Dictionary<string, EnemyProjectile>();
    public static Dictionary<string, PlayerProjectile> playerProjectiles = new Dictionary<string, PlayerProjectile>();
    public static int enemyProjectileCount = 0;
    public static int playerProjectileCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public static void RedirectProjectile(string projectileName, string direction)
    {

        switch (direction)
        {
            case "Up":
                enemyProjectiles[projectileName].RedirectUp();
                break;

            case "Down":
                enemyProjectiles[projectileName].RedirectDown();
                break;

            case "Left":
                enemyProjectiles[projectileName].RedirectLeft();
                break;

            case "Right":
                enemyProjectiles[projectileName].RedirectRight();
                break;
            case "Destroy":
                //Debug.Log("Player bullet destroyed 2?");
                GameObject projectileToDestroy = GameObject.Find(projectileName);
                Destroy(projectileToDestroy);

                if (enemyProjectiles.ContainsKey(projectileName))
                {
                    enemyProjectiles.Remove(projectileName);
                }
                else if (playerProjectiles.ContainsKey(projectileName))
                {
                    //Debug.Log("Player bullet destroyed 3?");
                    playerProjectiles.Remove(projectileName);
                }

                //Debug.Log("Projectile " + projectileName + " destroyed");
                break;
        }
    }
}
