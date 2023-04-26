using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : EnemyProjectile
{
    public BossProjectile(Vector3 exactProjectileDirection, float projectileSpeed, string projectileName, double projectileDamage, double damageModifier, int projectileDirectionX, int projectileDirectionY) : base(exactProjectileDirection, projectileSpeed, projectileName, projectileDamage, damageModifier, projectileDirectionX, projectileDirectionY)
    {
    }
}
