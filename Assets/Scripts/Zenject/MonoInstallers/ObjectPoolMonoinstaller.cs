using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPoolMonoinstaller : MonoInstaller
{
    public List<GameObject> Levels;
    public Transform SpawnPosition;

    public override void InstallBindings()
    {
        Container.Bind<ObjectPoolService>().AsSingle().WithArguments<PoolSettings>(new PoolSettings()).NonLazy();
        Container.Bind<List<GameObject>>().FromInstance(Levels).NonLazy();
        Container.Bind<Transform>().FromInstance(SpawnPosition).NonLazy();
    }
}
