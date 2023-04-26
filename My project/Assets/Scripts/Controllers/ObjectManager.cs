using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject baseEnemySpawnerPrefab;
    public GameObject gruntSpawnerPrefab;
    public GameObject goonSpawnerPrefab;
    public GameObject bruteSpawnerPrefab;
    public GameObject bossSpawnerPrefab;

    public GameObject baseEnemyProjectilePrefab;
    public GameObject baseEnemyPrefab;
    public GameObject playerProjectilePrefab;
    public GameObject gruntProjectilePrefab;
    public GameObject gruntPrefab;
    public GameObject goonProjectilePrefab;
    public GameObject goonPrefab;
    public GameObject bruteProjectilePrefab;
    public GameObject brutePrefab;
    public GameObject bossProjectilePrefab;
    public GameObject bossPrefab;

    public Dictionary<string, GameObject> projectiles;

    public GameObject TVPromptPrefab;
    public GameObject StoryTextPrefab;
    public GameObject VillainSpeakerPrefab;
    public GameObject PlayerSpeakerPrefab;
    public GameObject TVSpeakerPrefab;

    public static ObjectManager objectManagerInstance;

    private void Start()
    {
        objectManagerInstance = this;

        projectiles = new Dictionary<string, GameObject>();

        projectiles.Add("BaseEnemyProjectile", baseEnemyProjectilePrefab);
        projectiles.Add("GruntProjectile", gruntProjectilePrefab);
        projectiles.Add("GoonProjectile", goonProjectilePrefab);
        projectiles.Add("BruteProjectile", bruteProjectilePrefab);
        projectiles.Add("BossProjectile", bossProjectilePrefab);
    }

    public static void RedirectObject(string collidedName, string colliderName, string direction)
    {
        //Debug.Log("collidedName is " + collidedName + ", colliderName is " + colliderName);
        if (colliderName == "Player")
        {
            return;
        }
        else if (EnemyManager.enemies.ContainsKey(colliderName))
        {
            //Debug.Log("Collider is of type enemy");

            EnemyManager.RedirectEnemy(colliderName, direction);
        }
        else if (ProjectileManager.enemyProjectiles.ContainsKey(colliderName)) // If projectile hits enemy or enemy projectile, nothing happens, otherwise, destroy the projectile
        {
            // Bullet hit furniture or player bullet
            //Debug.Log("Projectile hit, being destroyed");
            ProjectileManager.RedirectProjectile(colliderName, "Destroy");
        }
        else if (ProjectileManager.playerProjectiles.ContainsKey(colliderName))
        {
            //Debug.Log("Player bullet destroyed 1?");
            ProjectileManager.RedirectProjectile(colliderName, "Destroy");
        }
    }
}
