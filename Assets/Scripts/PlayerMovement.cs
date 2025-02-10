using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _movementForce;
    private bool _isMovement;
    private Rigidbody _rigidbody;
    
    private float _currentForce;

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Vector3.up * _currentForce);
    }
}
