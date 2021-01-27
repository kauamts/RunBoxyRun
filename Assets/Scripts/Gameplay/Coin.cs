using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private int CoinScore = 100;
    #region Same as EnemyMovement
    private float runningSpeed;

    void Start()
    {
        runningSpeed = LevelController.runningSpeed;
    }

    void FixedUpdate()
    {
        if (PlayerController.isPlayerAlive)
        {
            if (this.transform.position.z > -30.00f)
            {
                this.transform.Translate(0f, 0f, runningSpeed * Time.deltaTime);
            }
            else
            {
                Destroy(this.gameObject);
            }

            runningSpeed = LevelController.runningSpeed;
        }
    }
    #endregion

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            GameManager.AddScore(CoinScore);
            //FUTURE NOTE: Add a 'gather' sound and animation.
            Destroy(this.gameObject);

        }
    }

}