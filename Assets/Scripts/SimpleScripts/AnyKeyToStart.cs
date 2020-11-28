using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// THIS CLASS DETECTS ANY INPUT TO CHANGE SCENES AND START THE GAME.
/// </summary>
public class AnyKeyToStart : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
            GameManager.Singleton.ChangeScene("Level_01");
    }
}
