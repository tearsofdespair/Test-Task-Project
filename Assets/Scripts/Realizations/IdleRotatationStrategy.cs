using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UnityEngine;

public class IdleRotationStrategy : IRotationStrategy
{
    public void Rotate(Transform transform, float speed)
    {
        transform.Rotate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
    }
}
