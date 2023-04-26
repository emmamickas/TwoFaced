using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEnemy
{
    private SpriteRenderer spriteRenderer;

    public Enemy(string enemyName, int enemyDirectionX, int enemyDirectionY, float enemySpeed, float shootLoop, float minShootDelay, float maxShootDelay, GameObject enemyObject, AudioClip shootSound) : base(enemyName, enemyDirectionX, enemyDirectionY, enemySpeed, shootLoop, minShootDelay, maxShootDelay, enemyObject, shootSound, 10)
    {
    }
}
