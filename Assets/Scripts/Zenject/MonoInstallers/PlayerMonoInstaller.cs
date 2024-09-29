using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class PlayerMonoInstaller : MonoInstaller
{
    public PlayerConfig PlayerConfig;
    public TextMeshProUGUI PointsText;

    public override void InstallBindings()
    {

        Container.Bind<PlayerConfig>().FromInstance(PlayerConfig).NonLazy();
        Container.Bind<TextMeshProUGUI>().FromInstance(PointsText).NonLazy();
    }
}