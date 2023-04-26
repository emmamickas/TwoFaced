using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Right Trigger Hit");
        ObjectManager.RedirectObject(gameObject.transform.parent.name, collision.gameObject.name, "Left");
        //ObjectManager.RedirectObject(gameObject.name, collision.gameObject.name, "Left");
    }
}
