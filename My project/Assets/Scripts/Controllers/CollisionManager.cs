using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public static void ProjectileCollision(GameObject projectile, GameObject hitObject)
    {
        //if (hitObject.name == "Player")
        //{
        //    // Player got hit by bullet
        //    Debug.Log("Player hit by enemy projectile");
        //    Destroy(projectile);
        //}
        //else if (!EnemyManager.enemies.ContainsKey(hitObject.name) && !ProjectileManager.enemyProjectiles.ContainsKey(hitObject.name)) // If projectile hits enemy or enemy projectile, nothing happens, otherwise, destroy the projectile
        //{
        //    // Bullet hit furniture or player bullet
        //    Debug.Log("Projectile hit, being destroyed");
        //    Destroy(projectile);
        //}
    }
}
