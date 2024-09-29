using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPoolMonoinstaller : MonoInstaller
{
    public ObjectPoolConfig Config;
    public Transform SpawnPosition;

    public override void InstallBindings()
    {
        Container.Bind<ObjectPoolService>().AsSingle().WithArguments<PoolSettings>(new PoolSettings()).NonLazy();
        Container.Bind<Transform>().FromInstance(SpawnPosition).NonLazy();
        Container.Bind<ObjectPoolConfig>().FromInstance(Config).NonLazy();
    }
}
