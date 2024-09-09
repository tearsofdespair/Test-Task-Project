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

        if (controls.Main.ChangeRotation.IsPressed())
        {
            RotateActive();
        }
        else
        {
            RotateIdle();
        }
    }


    private void RotateActive()
    {
        transform.Rotate(new Vector3(0, 0, 1) * RotationSpeed * Time.deltaTime);
    }

    private void RotateIdle()
    {
        transform.Rotate(new Vector3(0, 0, -1) * RotationSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
