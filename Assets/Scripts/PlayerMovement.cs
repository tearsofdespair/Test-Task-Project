using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float Speed;
    [SerializeField] public float RotationSpeed;
    private Controls controls;

    private void Awake()
    {
        controls = new Controls();
    }

    private void Update()
    {
        this.transform.position += transform.right * Speed * Time.deltaTime;
    }
}
