using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// THIS CLASS IS RESPONSIBLE TO DELAY THE ACTIVATION OF A SPRITE RENDERER IN "setTime" AMOUNT OF SECONDS.
/// </summary>
public class TextDisplayDelay : MonoBehaviour
{
    private SpriteRenderer rend;

    private float curTime;
    private float setTime;
        
    void Awake()
    {
        curTime = 0f;
        setTime = 3f;

        rend = this.GetComponent<SpriteRenderer>();
        
        if(rend.enabled == true)
            rend.enabled = false;
    }

    void Update()
    {
        if (curTime < setTime)
        {
            curTime += Time.deltaTime;
        }
        else
        {
            rend.enabled = true;
        }
    }
}
