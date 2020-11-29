using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Singleton { get; private set; }

    public static float runningSpeed;
    private float curTime;
    private float setTime;
    
    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        runningSpeed = -10f;
        curTime = 0f;
        setTime = 3f;
    }

    void FixedUpdate()
    {
        if(curTime < setTime)
        {
            curTime += Time.deltaTime;
        }
        else
        {
            runningSpeed *= 1.1f;
            curTime = 0f;
        }
    }
}
