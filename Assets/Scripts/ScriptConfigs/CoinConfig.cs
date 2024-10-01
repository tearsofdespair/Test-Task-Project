using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinConfig
{
    public float Speed = 0.3f;
    public Transform Player;

    public CoinConfig(float speed, Transform player)
    {
        Speed = speed;
        Player = player;
    }
}
