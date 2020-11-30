using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public static MusicController Singleton { get; private set; }

    private AudioSource myAudio;
    public AudioClip mainTheme;

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
    }

    void Start()
    {
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
        if (!pleaseDontStopTheMusic && myAudio.isPlaying == true)
        {
            myAudio.Stop();
        }
        else if (pleaseDontStopTheMusic && myAudio.isPlaying == false)
        {
            myAudio.Play();
        }
    }

    internal void ChangeTrack()
    {
        myAudio.clip = mainTheme;
        myAudio.Play();
    }
}
