using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;

    //Get the child component Text from the GameObject
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update the score and send it to the Screen GUI Text
    void Update()
    {
        scoreText.text = GameManager.scorePoints.ToString("0") + " Points";
    }
}
