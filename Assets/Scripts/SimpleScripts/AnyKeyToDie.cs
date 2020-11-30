using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// THIS CLASS DETECTS ANY INPUT TO CHANGE SCENES AND START THE GAME.
/// </summary>
public class AnyKeyToDie : MonoBehaviour
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
        if (((curTime > setTime)) && (Input.anyKeyDown || Input.touchCount > 0))
        {
            StartButton.startUp = true;
            Destroy(this.gameObject);
        }            
        else
            curTime += Time.fixedDeltaTime;
    }
}
