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
        
    }

    void Update()
    {
        
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
