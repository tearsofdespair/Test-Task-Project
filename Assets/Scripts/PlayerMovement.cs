using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
public class PlayerMovement : MonoBehaviour
{
    private float _speed;
    private float _rotationSpeed;
    private Controls controls;

    [Inject]
    public void Constract(PlayerConfig playerConfig)
    {
        _speed = playerConfig.MoveSpeed;
        _rotationSpeed = playerConfig.RotationSpeed;
    }

    private void Awake()
    {
        controls = new Controls();
    }

    private void Update()
    {
        this.transform.position += transform.right * _speed * Time.deltaTime;

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
        transform.Rotate(new Vector3(0, 0, 1) * _rotationSpeed * Time.deltaTime);
    }

    private void RotateIdle()
    {
        transform.Rotate(new Vector3(0, 0, -1) * _rotationSpeed * Time.deltaTime);
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
