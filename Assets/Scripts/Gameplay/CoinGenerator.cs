using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public void SpawnCoin(bool canSpan, float x, float y, float z, float a)
    {
        if (canSpan == true)
        {
            Instantiate<GameObject>(Resources.Load("Prefabs/Coin") as GameObject,
                        new Vector3(x, y, z + a),
                        new Quaternion(0f, 0f, 0f, 0f));
        }
    }
}
