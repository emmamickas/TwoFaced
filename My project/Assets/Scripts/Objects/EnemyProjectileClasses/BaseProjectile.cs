using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile
{
    public int projectileDirectionX = 1;
    public int projectileDirectionY = 1;
    public Vector3 exactProjectileDirection = new Vector3();
    private SpriteRenderer spriteRenderer;
    public string projectileName;
    public float projectileSpeed = 0.2f;
    public double projectileDamage;
    public double damageModifier;

    public BaseProjectile(Vector3 exactProjectileDirection, float projectileSpeed, string projectileName, double projectileDamage, double damageModifier, int projectileDirectionX, int projectileDirectionY)
    {
        this.exactProjectileDirection = exactProjectileDirection;
        this.projectileName = projectileName;
        this.projectileSpeed = projectileSpeed;
        this.projectileDamage = projectileDamage;
        this.damageModifier = damageModifier;
        this.projectileDirectionX = projectileDirectionX;
        this.projectileDirectionY = projectileDirectionY;
    }

    public double GetDamage()
    {
        return this.projectileDamage * this.damageModifier;
    }

    public void RedirectDown()
    {
        projectileDirectionY = -1; // Going down
    }

    public void RedirectUp()
    {
        projectileDirectionY = 1; // Going up
    }

    public void RedirectLeft()
    {
        projectileDirectionX = -1; // Going left
    }

    public void RedirectRight()
    {
        projectileDirectionX = 1; // Going right
    }
}
