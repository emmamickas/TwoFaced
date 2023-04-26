using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Upper Trigger Hit");
        ObjectManager.RedirectObject(gameObject.transform.parent.name, collision.gameObject.name, "Down");
        //ObjectManager.RedirectObject(gameObject.name, collision.gameObject.name, "Down");
    }
}
