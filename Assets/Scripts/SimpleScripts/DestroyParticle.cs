using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    private AudioSource audioS;

    //Explode and Destroy itself.
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        GameManager.Singleton.prepareToReset = true;
    }

    void Update()
    {
        if (!audioS.isPlaying)
            Destroy(this.gameObject);
    }
}
