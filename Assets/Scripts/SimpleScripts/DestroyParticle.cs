using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    //Explode and Destroy itself.
    void Start()
    {
        GameManager.Singleton.prepareToReset = true;
        Destroy(this.gameObject, 3f);
    }
}
