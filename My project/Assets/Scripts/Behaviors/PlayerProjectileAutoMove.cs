using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileAutoMove : MonoBehaviour
{
    public PlayerProjectile projectile;
    private GameObject projectileObject;

    void Start()
    {
        projectileObject = gameObject;
        if (ProjectileManager.playerProjectiles.Count > 0 && ProjectileManager.playerProjectiles.ContainsKey(projectileObject.name))
        {
            projectile = ProjectileManager.playerProjectiles[projectileObject.name];
        }
        else
        {
            projectile = null;
        }

        // No to this...
        //Rigidbody2D rigidBody = projectile.GetComponent<Rigidbody2D>();
        //rigidBody.velocity = new Vector3(moveSpeed, moveSpeed, 0);
    }

    void Update()
    {
        if (projectile == null)
        {
            if (ProjectileManager.playerProjectiles.ContainsKey(gameObject.name))
            {
                projectile = ProjectileManager.playerProjectiles[gameObject.name];
            }
            else // No projectile of this object's name being managed
            {
                return;
            }
        }

        // This seems to be exponential?
        // It isn't exponential...
        // There's just too many frames
        projectileObject.transform.Translate(Time.deltaTime * projectile.exactProjectileDirection.x * projectile.projectileSpeed, Time.deltaTime * projectile.exactProjectileDirection.y * projectile.projectileSpeed, 0f);
        // Debug.Log("Projectile position: " + projectileObject.transform.position.ToString());
    }
}
