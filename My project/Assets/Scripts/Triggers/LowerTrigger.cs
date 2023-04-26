using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Lower Trigger Hit");
        ObjectManager.RedirectObject(gameObject.transform.parent.name, collision.gameObject.name, "Up");
        //ObjectManager.RedirectObject(gameObject.name, collision.gameObject.name, "Up");
    }
}
