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

    private AudioSource myAudio;
    private string curScene;
    private string lastScene;

    public static bool pleaseDontStopTheMusic = true;

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

        myAudio = this.GetComponent<AudioSource>();

        pleaseDontStopTheMusic = true;

        if (!pleaseDontStopTheMusic)
        {
            myAudio.Stop();
        }
        else
        {
            myAudio.Play();
        }
    }

    void Update()
    {
        curScene = SceneManager.GetActiveScene().name;

        if (lastScene != curScene && curScene == "05_Parabens")
        {
            myAudio.Stop();
        }

        if (lastScene != curScene && curScene == "01_MainMenu")
        {
            AudioListener.volume = 1.0f;
            AudioListener.pause = false;
            myAudio.Play();
        }

        if (!pleaseDontStopTheMusic && myAudio.isPlaying == true)
        {
            myAudio.Pause();
        }
        else if (pleaseDontStopTheMusic && myAudio.isPlaying == false)
        {
            myAudio.UnPause();
        }

        lastScene = curScene;
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
