using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] public Transform Player;
    
    void Update()
    {
        transform.position = new Vector3(Player.position.x + 6.5f, transform.position.y, transform.position.z);
    }
}
