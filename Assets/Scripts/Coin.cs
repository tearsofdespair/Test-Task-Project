using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Coin : MonoBehaviour
{
    [Inject] public CoinConfig config;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, config.Player.position, config.Speed * Time.deltaTime);
    }


}