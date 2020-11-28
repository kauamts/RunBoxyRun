using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplayDelay : MonoBehaviour
{
    private SpriteRenderer rend;

    private float curTime;
    private float setTime;

    // Start is called before the first frame update
    void Awake()
    {
        curTime = 0f;
        setTime = 3f;

        rend = this.GetComponent<SpriteRenderer>();
        
        if(rend.enabled == true)
            rend.enabled = false;
    }

    // Update is called once per frame
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
