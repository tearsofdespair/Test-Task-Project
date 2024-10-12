using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPoolMonoinstaller : MonoInstaller
{
    public ObjectPoolConfig Config;
    public List<Level> Levels;
    public Transform SpawnPosition;
    private DiContainer _diContainer = new DiContainer();

    public override void InstallBindings()
    {
        /*Dictionary<GameObject, GameObjectPool> pools = madePools();*/
        /*Dictionary<Level, SpecialGameObjectPool<Level>> pools = madePools();*/

        Container.Bind<SpecialObjectPoolService<Level>>().AsSingle().WithArguments<PoolSettings, DiContainer>(new PoolSettings(), _diContainer).NonLazy();
        /*Container.Bind<ObjectPoolService>().AsSingle().WithArguments<PoolSettings>(new PoolSettings()).NonLazy();*/
        Container.Bind<Transform>().FromInstance(SpawnPosition).NonLazy();
        Container.Bind<List<Level>>().FromInstance(Levels).NonLazy();
        /*Container.Bind<Dictionary<GameObject, GameObjectPool>>().FromInstance(pools).NonLazy();*/
    }

    /*private Dictionary<Level, SpecialGameObjectPool<Level>> madePools()
    {
        Dictionary<Level, SpecialGameObjectPool<Level>> result = new Dictionary<Level, SpecialGameObjectPool<Level>>();

        PoolSettings standart = new PoolSettings();

        foreach(Level level in Levels)
        {
            result[level] = new SpecialGameObjectPool<Level>(level, standart, _diContainer);
        }

        return result;
    }*/

    /*private Dictionary<GameObject,GameObjectPool> madePools()
    {
        Dictionary<GameObject, GameObjectPool> result = new Dictionary<GameObject, GameObjectPool>();

        PoolSettings standart = new PoolSettings();

        foreach(GameObject gameObject in Config.Levels)
        {
            result[gameObject] = new GameObjectPool(gameObject, standart, _diContainer);
        }
        
        return result;
    }*/


}
