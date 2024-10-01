using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    [SerializeField] public List<Coin> Coins;
    [Inject] CoinConfig CoinConfig;
    private bool isSetted = false;

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

    private void OnEnable()
    {
        if (!isSetted)
        {
            foreach (Coin coin in Coins)
            {
                coin.config = CoinConfig;
                coin.enabled = true;
            }
        }
    }
}
