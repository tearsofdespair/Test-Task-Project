using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("sda;skdflj");
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerDamagable"))
        {
            Destroy(gameObject);
            Debug.Log("weoowekrowek");
        }
    }
}
