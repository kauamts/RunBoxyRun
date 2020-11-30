using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCollider : MonoBehaviour
{
    internal enum Side { Right, Left };
    [SerializeField]
    private Side screenSide;

    private void Start()
    {
        if (this.transform.position.x > 0)
        {
            screenSide = Side.Right;
        }
        else if (this.transform.position.x < 0)
        {
            screenSide = Side.Left;
        }
    }

    void OnMouseDown()
    {
        PlayerController.Singleton.MoveChar(screenSide);        
    }
}
