using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public Toggle arrowKeyToggle;
    public Toggle mouseToggle;
    public static bool arrowControls = false;
    public static bool mouseControls = false;
    public static double playerHealth = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        if (arrowKeyToggle == null || mouseToggle == null)
        {
            var allToggles = GameObject.FindObjectsOfType<Toggle>();

            for (int i = 0; i < allToggles.Length; i++)
            {
                if (allToggles[i].gameObject.name == "ArrowKeyToggle")
                {
                    this.arrowKeyToggle = allToggles[i];
                    this.arrowKeyToggle.isOn = false;
                    allToggles[i].isOn = false;
                }
                else if (allToggles[i].gameObject.name == "MouseToggle")
                {
                    this.mouseToggle = allToggles[i];
                    this.mouseToggle.isOn = false;
                    allToggles[i].isOn = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (arrowKeyToggle != null && arrowKeyToggle.isOn)
        {
            arrowControls = true;
        }
        else if (arrowKeyToggle != null && !arrowKeyToggle.isOn)
        {
            arrowControls = false;
        }

        if (mouseToggle != null && mouseToggle.isOn)
        {
            mouseControls = true;
        }
        else if (mouseToggle != null && !mouseToggle.isOn)
        {
            mouseControls = false;
        }
    }
}
