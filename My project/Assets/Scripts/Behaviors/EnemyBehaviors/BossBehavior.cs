using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : BaseEnemyBehavior
{
    private new void Start()
    {
        this.projectileName = "BossProjectile";

        base.Start();

        isDead = false;
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

        ProjectileManager.enemyProjectiles.Add(newProjectileObject.name, new BossProjectile(new Vector3(projectileDirection.x, projectileDirection.y, 0), 20f, newProjectileObject.name, 10, 1, 1, 1));

        ProjectileManager.enemyProjectileCount += 1;

        //Debug.Log("Added " + newProjectileObject.name + " to enemy projectile dictionary and instantiated new prefab object");

        enemy.lastShootTime = Time.time;
        enemy.nextShootTime = enemy.lastShootTime + Random.Range(enemy.minShootDelay, enemy.maxShootDelay);

        SoundEffectManager.PlayBossShoot();
    }

    protected override void TakeDamage(int damage)
    {
        enemy.enemyHealth -= damage;

        //Debug.Log("Boss taken the damage");

        if (enemy.enemyHealth <= 0)
        {
            isDead = true;

            enemy.enemyHealth = 0;
        }

        if (Level4Behavior.level4BehaviorInstance == null)
        {
            return;
        }

        Level4Behavior.level4BehaviorInstance.bossHealthDisplay.text = enemy.enemyHealth.ToString();
    }
}
