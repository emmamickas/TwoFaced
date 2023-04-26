using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Enemy : BaseEnemy
{
    public Level1Enemy(string enemyName, int enemyDirectionX, int enemyDirectionY, float enemySpeed, float shootLoop, float minShootDelay, float maxShootDelay, GameObject enemyObject, AudioClip shootSound, int enemyHealth) : base(enemyName, enemyDirectionX, enemyDirectionY, enemySpeed, shootLoop, minShootDelay, maxShootDelay, enemyObject, shootSound, enemyHealth)
    {
    }
}
