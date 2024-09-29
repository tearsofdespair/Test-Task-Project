using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField, Range(1, 15)] public float MoveSpeed;
    [field: SerializeField, Range(1, 180)] public float RotationSpeed;
}
