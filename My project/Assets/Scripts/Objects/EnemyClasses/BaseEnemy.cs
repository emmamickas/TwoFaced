using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy
{
    public int enemyDirectionX = 1;
    public int enemyDirectionY = 1;
    public float enemySpeed = 10f;
    public string enemyName;
    public float shootLoop = 1f;
    public int enemyHealth;
    public float nextShootTime = 0f;
    public float lastShootTime = 0f;
    public float minShootDelay = 1f;
    public float maxShootDelay = 3f;
    public GameObject enemyObject;
    public AudioClip shootSound;

    public BaseEnemy(string enemyName, int enemyDirectionX, int enemyDirectionY, float enemySpeed, float shootLoop, float minShootDelay, float maxShootDelay, GameObject enemyObject, AudioClip shootSound, int enemyHealth)
    {
        this.enemyName = enemyName;
        this.enemyDirectionX = enemyDirectionX;
        this.enemyDirectionY = enemyDirectionY;
        this.enemySpeed = enemySpeed;
        this.shootLoop = shootLoop;
        this.minShootDelay = minShootDelay;
        this.maxShootDelay = maxShootDelay;
        this.enemyObject = enemyObject;
        this.shootSound = shootSound;
        this.enemyHealth = enemyHealth;
    }

    public void RedirectDown()
    {
        enemyDirectionY = -1; // Going down
    }

    public void RedirectUp()
    {
        enemyDirectionY = 1; // Going up
    }

    public void RedirectLeft()
    {
        enemyDirectionX = -1; // Going left
    }

    public void RedirectRight()
    {
        enemyDirectionX = 1; // Going right
    }
}
