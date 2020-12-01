using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    //Explode and Destroy itself.
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }
}
