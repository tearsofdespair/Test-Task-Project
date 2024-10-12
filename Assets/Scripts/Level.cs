using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    [SerializeField] public List<Coin> Coins;
    private CoinConfig _coinConfig;
    private bool isSetted = false;

    [Inject]
    public void Construct(CoinConfig coinConfig)
    {
        _coinConfig = coinConfig;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(_coinConfig == null)
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
                coin.config = _coinConfig;
                coin.enabled = true;
            }
            isSetted = true;
        }
    }
}
