using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTriggers : MonoBehaviour
{
    private TextMeshPro _points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerDamagable"))
        {
            SceneManager.LoadScene(0);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Coins"))
        {
            _points.text = Convert.ToString(int.Parse(_points.text) + 1);
        }
    }
}
