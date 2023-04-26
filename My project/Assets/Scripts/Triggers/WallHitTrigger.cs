using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hit");
        EnemyManager.RedirectEnemy(collision.gameObject.name, "tbd");
    }
}
