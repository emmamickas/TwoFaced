using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public static Player playerInstance;
    public static GameObject playerObject;

    /// <summary>
    /// Either this function must be called or the instance has to be set from somewhere else before the game starts.
    /// </summary>
    private void SetPlayerInstance()
    {
        Player.playerInstance = this;
    }
}
