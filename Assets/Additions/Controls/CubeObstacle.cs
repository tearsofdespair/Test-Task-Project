using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObstacle : MonoBehaviour
{
    [SerializeField] public float Speed = 3f;
    [SerializeField] public float MaxDistance = 5f;
    private Vector2 startPosition;
    private Vector2 newPosition;

    void Start()
    {
        startPosition = transform.position;
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPosition.y = startPosition.y + (MaxDistance * Mathf.Sin(Time.time * Speed));
        transform.position = newPosition;
    }
}
