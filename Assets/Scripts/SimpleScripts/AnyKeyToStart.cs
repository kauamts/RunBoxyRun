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
        if (Time.realtimeSinceStartup > 3f && (Input.anyKeyDown || Input.touchCount > 0))
            GameManager.Singleton.ChangeScene("Level_01");
    }
}
