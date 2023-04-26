using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public static GameObject player;
    private float playerSpeed = 10f;
    private Player playerInstance;
    private GameObject projectilePrefab;
    private float elapsedTime = 0f;
    private float reloadTime = 0.5f;
    private Vector2 directionFacing;
    public TMP_Text playerHealthDisplay;
    public static GameObject mainCamera;
    public Animator animator;
    public float speed;
    public float prevSpeed;
    public float prevDirectionX;
    public float prevDirectionY;
    public bool makeChange;
    public static TMP_Text playerHealthDisplayStatic;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0f;
        player = GameObject.Find("Player");
        Player.playerObject = player;
        directionFacing = new Vector2(0, 1);
        playerInstance = new Player();
        playerHealthDisplay.text = PlayerInfo.playerHealth.ToString();

        if (ObjectManager.objectManagerInstance != null)
        {
            projectilePrefab = ObjectManager.objectManagerInstance.playerProjectilePrefab;
        }

        PlayerControl.mainCamera = GameObject.Find("MainCamera");
        this.prevSpeed = 0;
        prevDirectionX = 0;
        prevDirectionY = -1;
        this.makeChange = true;

        animator = GetComponent<Animator>();

        animator.SetFloat("Speed", prevSpeed);
        animator.SetFloat("DirectionX", prevDirectionX);
        animator.SetFloat("DirectionY", prevDirectionY);
        animator.SetBool("NoChange", this.makeChange);

        playerHealthDisplayStatic = playerHealthDisplay;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        speed = 0;
        makeChange = false;

        if (StoryBehaviors.storyBehaviorsInstance.currentlyReadingStory)
        {
            //Don't move!
        }
        else
        {
            if (ObjectManager.objectManagerInstance != null && this.projectilePrefab == null)
            {
                projectilePrefab = ObjectManager.objectManagerInstance.playerProjectilePrefab;
            }

            if (PlayerInfo.arrowControls)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    player.transform.Translate(0f, Time.deltaTime * playerSpeed, 0f);

                    directionFacing.y = 1;

                    speed = 1;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    player.transform.Translate(-1 * Time.deltaTime * playerSpeed, 0f, 0f);

                    directionFacing.x = -1;

                    speed = 1;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    player.transform.Translate(0f, -1 * Time.deltaTime * playerSpeed, 0f);

                    directionFacing.y = -1;

                    speed = 1;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    player.transform.Translate(Time.deltaTime * playerSpeed, 0f, 0f);

                    directionFacing.x = 1;

                    speed = 1;
                }


                if (!(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        directionFacing.x = -1;
                    }
                    else if (Input.GetKey(KeyCode.RightArrow))
                    {
                        directionFacing.x = 1;
                    }

                    directionFacing.y = 0;
                }
                else if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        directionFacing.x = 1;
                    }
                    else if (Input.GetKey(KeyCode.DownArrow))
                    {
                        directionFacing.x = -1;
                    }

                    directionFacing.x = 0;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    player.transform.Translate(0f, Time.deltaTime * playerSpeed, 0f);

                    directionFacing.y = 1;

                    speed = 1;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    player.transform.Translate(-1 * Time.deltaTime * playerSpeed, 0f, 0f);

                    directionFacing.x = -1;

                    speed = 1;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    player.transform.Translate(0f, -1 * Time.deltaTime * playerSpeed, 0f);

                    directionFacing.y = -1;

                    speed = 1;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    player.transform.Translate(Time.deltaTime * playerSpeed, 0f, 0f);

                    directionFacing.x = 1;

                    speed = 1;
                }


                if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        directionFacing.x = -1;
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        directionFacing.x = 1;
                    }

                    directionFacing.y = 0;
                }
                else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        directionFacing.x = 1;
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        directionFacing.x = -1;
                    }

                    directionFacing.x = 0;
                }
            }
        }

        if (Input.GetKey(KeyCode.Space) || (PlayerInfo.mouseControls && Input.GetKeyDown(KeyCode.Mouse0)))
        {
            //Debug.Log("Elapsed time = " + elapsedTime.ToString());
            //Debug.Log("Reload time = " + reloadTime.ToString());

            if (StoryBehaviors.storyBehaviorsInstance.inPromptArea)
            {
                StoryBehaviors.storyBehaviorsInstance.DisplayStory();
            }
            else if (elapsedTime > reloadTime)
            {
                this.Shoot();
                elapsedTime = 0f;
            }
        }

        if (this.prevDirectionX != this.directionFacing.x)
        {
            animator.SetFloat("DirectionX", this.directionFacing.x);
            this.prevDirectionX = this.directionFacing.x;

            makeChange = true;
        }
        if (this.prevDirectionY != this.directionFacing.y)
        {
            animator.SetFloat("DirectionY", this.directionFacing.y);
            this.prevDirectionY = this.directionFacing.y;

            makeChange = true;
        }
        if (this.prevSpeed != speed)
        {
            animator.SetFloat("Speed", speed);
            this.prevSpeed = speed;

            makeChange = true;
        }

        animator.SetBool("NoChange", makeChange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ProjectileManager.enemyProjectiles.ContainsKey(collision.gameObject.name)) // Player hit enemy projectile
        {
            PlayerInfo.playerHealth -= ProjectileManager.enemyProjectiles[collision.gameObject.name].GetDamage();
            playerHealthDisplay.text = PlayerInfo.playerHealth.ToString();
            // Player hit by bullet
            ObjectManager.RedirectObject(this.gameObject.name, collision.gameObject.name, "Destroy");

            if (PlayerInfo.playerHealth <= 0)
            {
                GameManager.PlayerDied();
            }
        }
    }

    void Shoot()
    {
        Vector3 spawnPos = player.transform.position;

        GameObject newProjectileObject = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

        newProjectileObject.name = newProjectileObject.name + ProjectileManager.playerProjectileCount.ToString();

        Vector3 projectileDirection = directionFacing;

        if (PlayerInfo.mouseControls)
        {
            Vector3 mousePositionScreen = Input.mousePosition;

            mousePositionScreen.z = 0.6f;

            /*Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePositionScreen);

            Vector2 mousePosition = new Vector2(worldPosition.x, worldPosition.y);

            Debug.Log("Projectile spawn position: " + spawnPos.ToString());
            Debug.Log("Mouse position: " + mousePosition.ToString());
            Debug.Log("Mouse position screen: " + mousePositionScreen.ToString()); */

            Vector3 mousePosition = Input.mousePosition;
            Vector3 spawnPosScreen = Camera.main.WorldToScreenPoint(spawnPos);

            Vector2 projectileDirection2 = new Vector2(mousePosition.x - spawnPosScreen.x, mousePosition.y - spawnPosScreen.y);

            projectileDirection2 = projectileDirection2.normalized;

            Debug.Log("Projectile Direction: " + projectileDirection2.ToString());

            projectileDirection = projectileDirection2;
        }

        ProjectileManager.playerProjectiles.Add(newProjectileObject.name, new PlayerProjectile(new Vector3(projectileDirection.x, projectileDirection.y, 0), 20f, newProjectileObject.name, 10, 1, 1, 1));

        ProjectileManager.playerProjectileCount += 1;

        PlayerSoundEffectManager.PlayPlayerShoot();

        //Debug.Log("Added " + newProjectileObject.name + " to enemy projectile dictionary and instantiated new prefab object");
    }
}
