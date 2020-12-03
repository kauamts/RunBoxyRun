using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTheBall : MonoBehaviour
{
    [SerializeField]
    private float xFloat;
    private float yFloat;
    private float zFloat;

    private float curSpeed;
    private float lastSpeed;

    // Start is called before the first frame update
    void Start()
    {
        xFloat = 10f;
        yFloat = 0f;
        zFloat = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerController.isPlayerAlive)
        {
            curSpeed = LevelController.runningSpeed;

            this.transform.Rotate(xFloat, yFloat, zFloat);

            if ((curSpeed != lastSpeed) && xFloat < 25f)
                xFloat += 0.5f;

            lastSpeed = curSpeed;
        }        
    }
}
