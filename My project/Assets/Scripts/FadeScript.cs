using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Color fadeColor = Color.black;
    public static FadeScript fadeScriptInstance;

    private void Start()
    {
        fadeScriptInstance = this;
    }

    public void Fade(string scene)
    {
        Initiate.Fade(scene, fadeColor, 0.5f);
    }
}
