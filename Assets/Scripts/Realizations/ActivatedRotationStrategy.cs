
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ActivatedRotationStrategy : IRotationStrategy
{
    public void Rotate(Transform transform, float speed)
    {
        transform.Rotate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
    }
}
