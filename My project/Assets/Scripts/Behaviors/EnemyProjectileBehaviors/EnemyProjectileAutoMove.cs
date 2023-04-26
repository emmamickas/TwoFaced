using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileAutoMove : BaseProjectileBehavior
{

    new void Update()
    {
        if (projectile == null)
        {
            if (ProjectileManager.enemyProjectiles.ContainsKey(gameObject.name))
            {
                projectile = ProjectileManager.enemyProjectiles[gameObject.name];
            }
            else // No projectile of this object's name being managed
            {
                return;
            }
        }

        base.Update();
    }
}
