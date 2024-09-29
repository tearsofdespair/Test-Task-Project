using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectPoolConfig", menuName = "Configs/ObjectPoolConfig")]
public class ObjectPoolConfig : ScriptableObject
{
    public List<GameObject> Levels;
}
