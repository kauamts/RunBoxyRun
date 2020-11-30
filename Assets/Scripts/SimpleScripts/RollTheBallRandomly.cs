using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ROTATES THE PARENT OBJECT IN ALL DIRECTIONS AT RANDOM SPEEDS.
/// </summary>
public class RollTheBallRandomly : MonoBehaviour
{
    private float xFloat;
    private float yFloat;
    private float zFloat;
    private float curTime;
    private float setTime;
        
    void Start()
    {
        setTime = 1f;
        curTime = setTime;
    }

    void FixedUpdate()
    {
        if(curTime < setTime)
        {
            curTime += Time.deltaTime;
        }
        else
        {
            xFloat = Random.Range(-10f, 10f);
            yFloat = Random.Range(-10f, 10f);
            zFloat = Random.Range(-10f, 10f);

            curTime = 0f;
        }
        
        this.transform.Rotate(xFloat, yFloat, zFloat);
    }
}
