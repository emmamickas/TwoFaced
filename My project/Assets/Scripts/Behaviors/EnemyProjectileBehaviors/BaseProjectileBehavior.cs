using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectileBehavior : MonoBehaviour
{
    public EnemyProjectile projectile;
    protected GameObject projectileObject;

    void Start()
    {
        projectileObject = gameObject;
        if (ProjectileManager.enemyProjectiles.Count > 0 && ProjectileManager.enemyProjectiles.ContainsKey(projectileObject.name))
        {
            projectile = ProjectileManager.enemyProjectiles[projectileObject.name];
        }
        else
        {
            projectile = null;
        }

        // No to this...
        //Rigidbody2D rigidBody = projectile.GetComponent<Rigidbody2D>();
        //rigidBody.velocity = new Vector3(moveSpeed, moveSpeed, 0);
    }

    protected void Update()
    {
        // This seems to be exponential?
        // It isn't exponential...
        // There's just too many frames
        projectileObject.transform.Translate(Time.deltaTime * projectile.exactProjectileDirection.x * projectile.projectileSpeed, Time.deltaTime * projectile.exactProjectileDirection.y * projectile.projectileSpeed, 0f);
        // Debug.Log("Projectile position: " + projectileObject.transform.position.ToString());
    }
}
