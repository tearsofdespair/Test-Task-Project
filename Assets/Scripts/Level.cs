using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    [SerializeField] public Coin Coins;
    CoinConfig CoinConfig;

    // Start is called before the first frame update
    void Start()
    {
        if(CoinConfig == null)
        {
            Debug.Log("nifiga netu");
        }
        else
        {
            Debug.Log("Chto-to est");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
