using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// THIS IS THE SINGLETON CLASS THAT RUNS THE SHOW, IT CALLS GAME STATES AND CHANGES SCENES.
/// EVERYONE ONE REFERENCES FROM IT AND BY BEING STATIC IT MAKES SURE THE DATA IS CONSISTENT
/// ACROSS THE ENTIRE PROJECT.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Singleton { get; private set; }
    
    public bool prepareToReset;
    [SerializeField]
    private float resetCountdown;

    public static int scorePoints;
    public static int highestScore;


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
        resetCountdown = 5f;
    }

    void Update()
    {
        //GAME OVER, MAN!
        if(prepareToReset)
        {
            if (resetCountdown <= 0f)
            {
                ChangeScene("Level_01");
                ResetScore();
                resetCountdown = 5f;
                prepareToReset = false;
            }
            else if(resetCountdown <= 4f)
            {
                Time.timeScale = 1f;
                resetCountdown -= Time.deltaTime;
            }
            else
            {
                resetCountdown -= Time.deltaTime;
            }
        }
        
    }

    public static void AddScore(int value) // Coins
    {
        //scorePoints = scorePoints + value;
        scorePoints += value;
    }

    public void ResetScore()
    {
        if (scorePoints > highestScore)
            highestScore = scorePoints;
        scorePoints = 0;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void ChangeScene(Scene myScene)
    {
        SceneManager.LoadScene(myScene.name, LoadSceneMode.Single);
    }
}
