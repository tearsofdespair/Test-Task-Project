using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PlayerTriggers : MonoBehaviour
{
    private TextMeshProUGUI _pointsText;


    [Inject]
    public void Constract(TextMeshProUGUI pointsText)
    {
        _pointsText = pointsText;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerDamagable"))
        {
            SceneManager.LoadScene(0);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Coins"))
        {
            _pointsText.text = Convert.ToString(int.Parse(_pointsText.text) + 1);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("CoinCheck"))
        {
            Coin script = collision.gameObject.GetComponentInParent<Coin>();
            Debug.Log(script.ToString());
            script.enabled = true;
        }
    }
}
