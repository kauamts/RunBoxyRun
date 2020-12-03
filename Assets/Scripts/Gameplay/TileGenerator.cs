using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject tile01;
    private float runningSpeed;

    private Vector3 endOfTheLine;
    private Quaternion defaultRotation;

    void Start()
    {
        runningSpeed = LevelController.runningSpeed;
        endOfTheLine = new Vector3(0f, 0f, 300f);
        defaultRotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    void FixedUpdate()
    {
        if(PlayerController.isPlayerAlive)
        {
            if (this.transform.position.z > -30.00f)
            {
                this.transform.Translate(0f, 0f, runningSpeed * Time.deltaTime);
            }
            else
            {
                Instantiate<GameObject>(tile01, endOfTheLine, defaultRotation);
                Destroy(this.gameObject);
            }

            runningSpeed = LevelController.runningSpeed;
        }        
    }
}
