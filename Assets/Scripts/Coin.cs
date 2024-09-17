using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] public float Speed = 0.3f;
    [SerializeField] public Transform Player;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
    }


}