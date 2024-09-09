using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IRotationStrategy
{
    public abstract void Rotate(Transform transform, float speed);
}
