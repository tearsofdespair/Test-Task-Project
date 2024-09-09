using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float Speed;

    private void Update()
    {
        this.transform.position += transform.right * Speed * Time.deltaTime;
    }
}
