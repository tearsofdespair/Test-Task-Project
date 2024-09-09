using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float Speed;
    [SerializeField] public float RotationSpeed;
    public IRotationStrategy Strategy;
    private void Update()
    {
        this.transform.position += transform.right * Speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Strategy = new ActivatedRotationStrategy();
        }
        else
        {
            Strategy = new IdleRotationStrategy();
        }

        Strategy.Rotate(this.transform, RotationSpeed);
    }
}
