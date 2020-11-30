using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// THIS CLASS DETECTS ANY INPUT TO CHANGE SCENES AND START THE GAME.
/// </summary>
public class AnyKeyToStart : MonoBehaviour
{
    [SerializeField]
    private float curTime;
    [SerializeField]
    private float setTime;

    void Awake()
    {
        curTime = 0f;
        setTime = 3f;
    }

    void Update()
    {
        if ((curTime > setTime) && (Input.anyKeyDown || Input.touchCount > 0))
            GameManager.Singleton.ChangeScene("Level_01");
        else
            curTime += Time.deltaTime;
    }
}
