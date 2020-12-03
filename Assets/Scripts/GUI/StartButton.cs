using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// THIS CLASS DETECTS ANY INPUT TO CHANGE SCENES AND START THE GAME.
/// </summary>
public class StartButton : MonoBehaviour
{
    private SpriteRenderer spriteRen;
    private BoxCollider boxCol;

    internal static bool startUp;

    void Awake()
    {
        Time.timeScale = 0f;

        startUp = false;
    }

    void Start()
    {
        spriteRen = this.GetComponent<SpriteRenderer>();
        boxCol = this.GetComponent<BoxCollider>();

        spriteRen.enabled = false;
        boxCol.enabled = false;
    }

    void Update()
    {
        if (startUp)
        {
            spriteRen.enabled = true;
            boxCol.enabled = true;
        }
    }

    void OnMouseUpAsButton()
    {
        MusicController.Singleton.ChangeTrack();
        MusicController.pleaseDontStopTheMusic = true;

        //activate all GUI

        Time.timeScale = 1f;

        Destroy(this.gameObject);
    }
}
