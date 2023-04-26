using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level4Behavior : SpecialLevelBehavior
{
    bool initialDoorClosed = false;
    bool finalDoorClosed = true;
    bool inFinalRoom = false;
    bool middleDoorOpen = false;
    public static GameObject wall1;
    public GameObject wall2;
    public GameObject doorEntrance;
    public static int level4Phase;
    public TMP_Text bossHealthDisplay;
    public static Level4Behavior level4BehaviorInstance;
    public static bool okToEnterFinalBattle;
    public GameObject finalTV;

    // Start is called before the first frame update
    void Start()
    {
        this.doorEntrance = GameObject.Find("DoorEntrance");
        Debug.Log("Got here 1...");
        this.doorEntrance.SetActive(false);
        Debug.Log("Got here 2...");
        this.wall2 = GameObject.Find("WallToClose1");
        Debug.Log("Got here 3...");
        level4Phase = 1;
        Debug.Log("Got here 4...");
        bossHealthDisplay.text = 100.ToString();
        Debug.Log("Got here 5...");
        level4BehaviorInstance = this;
        Debug.Log("Got here 6...");
        okToEnterFinalBattle = false;
        Debug.Log("Got here 7...");
        finalTV = GameObject.Find("FinalTV");
        Debug.Log("Got here 8...");
        finalTV.SetActive(false);
        Debug.Log("Got here 9...");

        if (Player.playerObject != null && Player.playerObject.transform != null && Player.playerObject.transform.position != null)
        {
            Player.playerObject.transform.position = new Vector3(-1f, -10.7f, 0f);
        }
        Debug.Log("Got here 10...");
    }

    // Update is called once per frame
    void Update()
    {
        if (level4BehaviorInstance == null)
        {
            level4BehaviorInstance = this;
        }

        // Special camera controls
        if (PlayerControl.player.transform.position.y <= -7.5 && !this.initialDoorClosed)
        {
            //Debug.Log("Camera should be at lower default.");
            PlayerControl.mainCamera.transform.position = new Vector3(0.5f, PlayerControl.player.transform.position.y + 1.8f, -8.35f);
            level4Phase = 1;
        }
        else if (PlayerControl.player.transform.position.y < -3.5 && !this.inFinalRoom)
        {
            //Debug.Log("Camera should be at middle default.");
            this.CloseInitialDoor();
            PlayerControl.mainCamera.transform.position = new Vector3(0.5f, -5.7f, -8.35f);
            level4Phase = 2;
        }
        else if (PlayerControl.player.transform.position.y < 9.7 && !this.inFinalRoom && okToEnterFinalBattle)
        {
            //Debug.Log("Camera should go up.");
            PlayerControl.mainCamera.transform.position = new Vector3(PlayerControl.mainCamera.transform.position.x, PlayerControl.player.transform.position.y - 2.2f, PlayerControl.mainCamera.transform.position.z);
            level4Phase = 3;
        }
        else if ((level4Phase == 3 || level4Phase == 4) && okToEnterFinalBattle)
        {
            //Debug.Log("Camera should be at higher default.");
            this.CloseFinalDoor();
            this.inFinalRoom = true;
            PlayerControl.mainCamera.transform.position = new Vector3(0.5f, 12.5f, -8.35f);
            level4Phase = 4;
        }

        if (PlayerControl.player.transform.position.y > 8.5 && this.finalDoorClosed && !this.inFinalRoom)
        {
            this.OpenFinalDoor();
        }

        if (StoryBehaviors.readStory && !middleDoorOpen)
        {
            this.OpenMiddleDoor();
            okToEnterFinalBattle = true;
        }
        
        if (EnemyManager.enemiesKilled >= 1)
        {
            this.doorEntrance.SetActive(true);
            finalTV.SetActive(true);
        }
    }

    private void OpenFinalDoor()
    {
        BoxCollider2D boxCollider1 = wall2.GetComponent<BoxCollider2D>();

        boxCollider1.enabled = false;

        wall2.SetActive(false);

        this.finalDoorClosed = false;
    }

    private void OpenMiddleDoor()
    {
        GameObject wall2 = GameObject.Find("WallToOpen2");

        BoxCollider2D boxCollider2 = wall2.GetComponent<BoxCollider2D>();

        boxCollider2.enabled = false;

        //GameObject trigger1 = GameObject.Find("UpperTriggerToOpen");

        //trigger1.SetActive(false);

        GameObject door2 = GameObject.Find("Single-Flush 36\" x 84\" [370392]");

        door2.SetActive(false);

        this.middleDoorOpen = true;

        AmbienceManager.PlayDoorOpen();
    }

    private void CloseInitialDoor()
    {
        //GameObject wall1 = GameObject.Find("WallToOpen1");

        BoxCollider2D boxCollider1 = wall1.GetComponent<BoxCollider2D>();

        boxCollider1.enabled = true;

        wall1.SetActive(true);

        this.initialDoorClosed = true;
    }

    private void CloseFinalDoor()
    {
        BoxCollider2D boxCollider1 = wall2.GetComponent<BoxCollider2D>();

        boxCollider1.enabled = true;

        wall2.SetActive(true);

        this.finalDoorClosed = true;
    }
}
