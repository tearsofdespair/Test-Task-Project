using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPoolMonoinstaller : MonoInstaller
{
    public ObjectPoolConfig Config;
    public Transform SpawnPosition;
    private DiContainer _diContainer = new DiContainer();

    public override void InstallBindings()
    {
        Dictionary<GameObject, GameObjectPool> pools = madePools();


        Container.Bind<ObjectPoolService>().AsSingle().WithArguments<PoolSettings>(new PoolSettings()).NonLazy();
        Container.Bind<Transform>().FromInstance(SpawnPosition).NonLazy();
        Container.Bind<ObjectPoolConfig>().FromInstance(Config).NonLazy();
        Container.Bind<Dictionary<GameObject, GameObjectPool>>().FromInstance(pools).NonLazy();
    }

    private Dictionary<GameObject,GameObjectPool> madePools()
    {
        Dictionary<GameObject, GameObjectPool> result = new Dictionary<GameObject, GameObjectPool>();

        PoolSettings standart = new PoolSettings();

        foreach(GameObject gameObject in Config.Levels)
        {
            result[gameObject] = new GameObjectPool(gameObject, standart, _diContainer);
        }
        
        return result;
    }
}
