using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    void FixedUpdate()
    {
        this.transform.Rotate(0, 5f, 0);
    }
}
