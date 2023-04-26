using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelManager.playingGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        GameManager.level = 0;
        SceneManager.LoadScene(sceneName: "Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
