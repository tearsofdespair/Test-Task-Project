using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class CoinsMonoinstaller : MonoInstaller
{
    public float CoinSpeed;
    public Transform PlayerPosition;

    public override void InstallBindings()
    {
        CoinConfig coinConfig = new CoinConfig(CoinSpeed, PlayerPosition);

        Container.Bind<CoinConfig>().AsSingle().WithArguments(CoinSpeed, PlayerPosition).NonLazy();
    }
}
