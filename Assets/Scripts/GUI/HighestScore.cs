using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScore : MonoBehaviour
{
    private Text highestScoreText;

    //Get the child component Text from the GameObject
    void Start()
    {
        highestScoreText = GetComponent<Text>();
    }

    // Update the HighScore and send it to the Screen GUI Text
    void Update()
    {
        if(GameManager.highestScore > 0)
            highestScoreText.text = "Highscore: " + GameManager.highestScore.ToString("0");
    }
}
