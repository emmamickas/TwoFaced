using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryBehaviors : MonoBehaviour
{
    GameObject TVPromptObject = null;
    GameObject storyTextObject = null;
    GameObject speakerObject = null;
    public bool inPromptArea = false;
    public bool currentlyReadingStory = false;
    public static Dictionary<int, bool> levelCompletion = new Dictionary<int, bool>();
    private int currentStoryTextIndex = 0;
    public TMP_Text storyText;
    public static StoryBehaviors storyBehaviorsInstance = null;
    public float storyDelay = 0.5f;
    public float lastStoryHit = 0f;
    public static bool readStory = false;

    private void Start()
    {
        StoryBehaviors.storyBehaviorsInstance = this;
        readStory = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.name == "Player")
        //{
        //    Debug.Log("Player has entered TV area");
        //}

        if ((collision.name == "Player" && EnemyManager.enemies.Count <= 0 && EnemyManager.enemyCount >= LevelManager.levelManagerInstance.levels[GameManager.level].totalEnemies) || (collision.name == "Player" && GameManager.level == 4))
        {
            this.TVPromptObject = Instantiate(ObjectManager.objectManagerInstance.TVPromptPrefab, LevelManager.levelManagerInstance.levels[GameManager.level].storyPromptPosition, Quaternion.identity);

            StoryBehaviors.storyBehaviorsInstance.inPromptArea = true;

            AmbienceManager.PlayTvTurnOn();
        }
        else if (collision.name == "Player" && GameManager.level == 5)
        {
            Debug.Log("?");

            this.TVPromptObject = Instantiate(ObjectManager.objectManagerInstance.TVPromptPrefab, LevelManager.levelManagerInstance.levels[GameManager.level].storyPromptPosition, Quaternion.identity);

            StoryBehaviors.storyBehaviorsInstance.inPromptArea = true;

            AmbienceManager.PlayTvTurnOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            //Debug.Log("Player has exited TV area");
        }

        if (this.TVPromptObject != null)
        {
            Destroy(this.TVPromptObject);
            this.TVPromptObject = null;

            StoryBehaviors.storyBehaviorsInstance.inPromptArea = false;
        }
    }

    public void DisplayStory()
    {
        if (Time.time <= this.lastStoryHit + this.storyDelay)
        {
            return;
        }

        if (this.currentStoryTextIndex == 0 || this.storyTextObject == null || this.storyText == null)
        {
            this.storyTextObject = Instantiate(ObjectManager.objectManagerInstance.StoryTextPrefab, LevelManager.levelManagerInstance.levels[GameManager.level].storyTextPosition, Quaternion.identity);

            this.storyText = this.storyTextObject.transform.Find("StoryTextCanvas").GetComponent<TMP_Text>();
        }

        this.currentlyReadingStory = true;

        if (this.currentStoryTextIndex < LevelManager.levelManagerInstance.levels[GameManager.level].storyTexts.Count) 
        {
            // Debug.Log("Should I be in here?");
            // Debug.Log("Story count = " + LevelManager.levelManagerInstance.levels[GameManager.level].storyTexts.Count + ", story index = " + this.currentStoryTextIndex.ToString());

            AmbienceManager.PlayTextBoxSound();

            storyText.text = LevelManager.levelManagerInstance.levels[GameManager.level].storyTexts[this.currentStoryTextIndex].Item1;

            if (this.speakerObject)
            {
                Destroy(this.speakerObject);
            }

            switch (LevelManager.levelManagerInstance.levels[GameManager.level].storyTexts[this.currentStoryTextIndex].Item2)
            {
                case "Player":
                    this.speakerObject = Instantiate(ObjectManager.objectManagerInstance.PlayerSpeakerPrefab, LevelManager.levelManagerInstance.levels[GameManager.level].speakerPosition, Quaternion.identity);

                    break;

                case "TV":
                    this.speakerObject = Instantiate(ObjectManager.objectManagerInstance.TVSpeakerPrefab, LevelManager.levelManagerInstance.levels[GameManager.level].speakerPosition, Quaternion.identity);

                    break;

                case "Villain":
                    this.speakerObject = Instantiate(ObjectManager.objectManagerInstance.VillainSpeakerPrefab, LevelManager.levelManagerInstance.levels[GameManager.level].speakerPosition, Quaternion.identity);

                    break;
            }

            this.currentStoryTextIndex++;

            this.lastStoryHit = Time.time;
        }
        else if (this.currentStoryTextIndex >= LevelManager.levelManagerInstance.levels[GameManager.level].storyTexts.Count)
        {
            // Debug.Log("We made it here");

            Destroy(this.storyTextObject);

            if (this.speakerObject)
            {
                Destroy(this.speakerObject);
            }

            this.storyTextObject = null;
            this.storyText = null;
            this.speakerObject = null;

            this.currentStoryTextIndex = 0;
            this.lastStoryHit = Time.time;

            if (GameManager.level != 5)
            {
                this.currentlyReadingStory = false;
            }

            readStory = true;

            LevelManager.levelManagerInstance.levels[GameManager.level].OpenDoor();
        }
    }
}
