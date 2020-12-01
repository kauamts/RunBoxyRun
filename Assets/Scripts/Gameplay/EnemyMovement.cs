using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float runningSpeed;

    void Start()
    {
        runningSpeed = LevelController.runningSpeed;
    }

    void FixedUpdate()
    {
        if(this.transform.position.z > -30.00f)
        {
            this.transform.Translate(0f, 0f, runningSpeed*Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }

        runningSpeed = LevelController.runningSpeed;
    }
}
