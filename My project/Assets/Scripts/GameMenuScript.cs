using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReturnToMenu()
    {
        LevelManager.playingGame = false;
        SceneManager.LoadScene(sceneName: "Main Menu");
    }
}
