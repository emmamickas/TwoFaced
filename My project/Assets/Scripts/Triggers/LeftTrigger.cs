using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Left Trigger Hit");
        ObjectManager.RedirectObject(gameObject.transform.parent.name, collision.gameObject.name, "Right");
        //ObjectManager.RedirectObject(gameObject.name, collision.gameObject.name, "Right");
    }
}
