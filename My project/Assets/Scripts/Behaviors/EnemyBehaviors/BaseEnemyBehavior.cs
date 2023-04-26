using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class BaseEnemyBehavior : MonoBehaviour
{
    public BaseEnemy enemy;
    public GameObject enemyObject;
    protected GameObject projectilePrefab;
    protected string projectileName;
    public Animator animator;
    public float speed;
    public float prevDirectionX;
    public float prevDirectionY;
    public float prevSpeed;
    public bool makeChange;
    public bool isDead;

    protected void Start()
    {

        if (GameManager.level == 5)
        {
            isDead = true;
            makeChange = false;

            return;
        }

        if (this.projectileName == null)
        {
            this.projectileName = "BaseEnemyProjectile";
        }

        enemyObject = gameObject;

        projectilePrefab = ObjectManager.objectManagerInstance.projectiles[projectileName];

        //Debug.Log("Found " + projectilePrefab.name);

        if (EnemyManager.enemies.Count > 0 && EnemyManager.enemies.ContainsKey(enemyObject.name))
        {
            enemy = EnemyManager.enemies[enemyObject.name];

            prevSpeed = 0;
            prevDirectionX = enemy.enemyDirectionX;
            prevDirectionY = enemy.enemyDirectionY;
            isDead = false;
        }
        else
        {
            enemy = null;
        }

        animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.SetFloat("Speed", 1);
            animator.SetFloat("DirectionX", enemy.enemyDirectionX);
            animator.SetFloat("DirectionY", enemy.enemyDirectionY);
            animator.SetBool("MakeChange", true);
            animator.SetBool("IsDead", false);
        }
    }

    protected void Update()
    {
        if (enemy == null)
        {
            if (EnemyManager.enemies.ContainsKey(gameObject.name))
            {
                enemy = EnemyManager.enemies[gameObject.name];
            }
            else // No enemy of this object's name being managed
            {
                return;
            }
        }

        this.makeChange = false;

        if (isDead)
        {
            return;
        }

        // This seems to be exponential?
        // It isn't exponential...
        // There's just too many frames
        enemyObject.transform.Translate(Time.deltaTime * enemy.enemySpeed * enemy.enemyDirectionX, Time.deltaTime * enemy.enemySpeed * enemy.enemyDirectionY, 0f);
        // Debug.Log("Enemy position: " + enemyObject.transform.position.ToString());

        if (enemy.nextShootTime < Time.time)
        {
            this.Shoot();
        }

        if (animator != null)
        {
            if (prevSpeed != 1)
            {
                animator.SetFloat("Speed", 1);
                prevSpeed = 1;
                makeChange = true;
            }

            if (prevDirectionX != enemy.enemyDirectionX)
            {
                animator.SetFloat("DirectionX", enemy.enemyDirectionX);
                prevDirectionX = enemy.enemyDirectionX;
                makeChange = true;
            }

            if (prevDirectionY != enemy.enemyDirectionY)
            {
                animator.SetFloat("DirectionY", enemy.enemyDirectionY);
                prevDirectionY = enemy.enemyDirectionY;
                makeChange = true;
            }

            animator.SetBool("MakeChange", makeChange);
        }
    }

    protected abstract void Shoot();

    protected abstract void TakeDamage(int damage);

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (ProjectileManager.playerProjectiles.ContainsKey(collision.gameObject.name)) // Enemy hit player projectile
        {
            PlayerProjectile playerProjectile = ProjectileManager.playerProjectiles[collision.gameObject.name];

            if (isDead)
            {
                return; // Dead before call, don't do a bunch of extra stuff!
            }

            TakeDamage((int)playerProjectile.GetDamage());

            //if (GameManager.level == 4)
            //{
            //    Level4Behavior.level4BehaviorInstance.bossHealthDisplay.text = enemy.enemyHealth.ToString();
            //}

            if (enemy.enemyHealth <= 0)
            {
                // Enemy died
                EnemyManager.enemiesKilled += 1;
                //Debug.Log("Killed " + EnemyManager.enemiesKilled.ToString() + " enemies");

                if (this.gameObject.name.Contains("boss") || this.gameObject.name.Contains("Boss"))
                {
                    if (isDead)
                    {
                        animator.SetFloat("Speed", 0);
                        animator.SetBool("MakeChange", true);
                        animator.SetBool("IsDead", true);
                    }

                    animator.SetBool("MakeChange", false);

                    return;
                }

                ObjectManager.RedirectObject(this.gameObject.name, collision.gameObject.name, "Destroy");
                EnemyManager.enemies.Remove(name);
                Destroy(gameObject);
            }
        }
    }
}
