using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Singleton { get; private set; }

    public static float runningSpeed;
    public int difficultyLevel;

    private float curTime;
    private float setTime;
    
    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        difficultyLevel = 1;
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
            runningSpeed *= 1.05f;
            difficultyLevel++;
            curTime = 0f;
        }
    }
}
