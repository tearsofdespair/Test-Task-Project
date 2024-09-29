using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class PlayerMonoInstaller : MonoInstaller
{
    public float MoveSpeed = 1.0f;
    public float RotationSpeed = 1.0f;
    public TextMeshProUGUI PointsText;

    public override void InstallBindings()
    {
        List<float> speeds = new List<float>() { MoveSpeed, RotationSpeed};

        Container.Bind<List<float>>().FromInstance(speeds).NonLazy();
        Container.Bind<TextMeshProUGUI>().FromInstance(PointsText).NonLazy();
    }
}