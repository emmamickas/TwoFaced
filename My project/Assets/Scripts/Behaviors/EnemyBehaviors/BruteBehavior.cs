using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteBehavior : BaseEnemyBehavior
{
    private new void Start()
    {
        this.projectileName = "BruteProjectile";

        base.Start();
    }

    protected override void Shoot()
    {
        GameObject player = Player.playerObject;

        Vector3 spawnPos = transform.position;

        //Debug.Log("Player position: " + player.transform.position.ToString());
        //Debug.Log("Projectile spawn position: " + spawnPos.ToString());

        Vector2 projectileDirection = new Vector2(player.transform.position.x - spawnPos.x, player.transform.position.y - spawnPos.y);

        projectileDirection = projectileDirection.normalized;

        //Debug.Log("Projectile Direction: " + projectileDirection.ToString());

        GameObject newProjectileObject = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

        newProjectileObject.name = newProjectileObject.name + ProjectileManager.enemyProjectileCount.ToString();

        ProjectileManager.enemyProjectiles.Add(newProjectileObject.name, new BruteProjectile(new Vector3(projectileDirection.x, projectileDirection.y, 0), 20f, newProjectileObject.name, 5, 1, 1, 1));

        ProjectileManager.enemyProjectileCount += 1;

        //Debug.Log("Added " + newProjectileObject.name + " to enemy projectile dictionary and instantiated new prefab object");

        enemy.lastShootTime = Time.time;
        enemy.nextShootTime = enemy.lastShootTime + Random.Range(enemy.minShootDelay, enemy.maxShootDelay);

        SoundEffectManager.PlayBruteShoot();
    }

    protected override void TakeDamage(int damage)
    {
        enemy.enemyHealth -= damage;
    }
}
