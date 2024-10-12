using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpecialObjectPoolService<D> where D : Component
{
    private readonly PoolSettings _defaultSettings;
    private readonly Dictionary<GameObject, SpecialGameObjectPool<D>> _poolsMap = new(32);
    private readonly Dictionary<GameObject, GameObject> _spawnedGameObjectsMap = new(256);
    private readonly DiContainer _diContainer;

    public IEnumerable<GameObject> SpawnedGameObjects => _spawnedGameObjectsMap.Keys;

    public int SpawnedGameObjectsCount => _spawnedGameObjectsMap.Count;

    public SpecialObjectPoolService(PoolSettings defaultSettings, DiContainer diContainer)
    {
        _defaultSettings = defaultSettings;
        _diContainer = diContainer;
    }

    public T Spawn<T>(T prefab) where T : Component
    {
        GameObject instance = Spawn(prefab.gameObject);
        return instance.GetComponent<T>();
    }

    public GameObject Spawn(GameObject prefab)
    {
        GameObjectPool pool = GetOrCreatePool(prefab);
        GameObject instance = pool.Get();
        _spawnedGameObjectsMap.Add(instance, prefab);
        return instance;
    }

    public void AddPool(GameObject gameObject, SpecialGameObjectPool<D> pool)
    {
        _poolsMap.Add(gameObject, pool);
    }

    public void AddPools(Dictionary<GameObject, SpecialGameObjectPool<D>> pools)
    {
        foreach (KeyValuePair<GameObject, SpecialGameObjectPool<D>> pair in pools)
        {
            _poolsMap.Add(pair.Key, pair.Value);
        }
    }

    public void Despawn(Component prefab)
    {
        Despawn(prefab.gameObject);
    }

    public void Despawn(GameObject instance)
    {
        GameObject prefab = _spawnedGameObjectsMap[instance];
        SpecialGameObjectPool<D> pool = _poolsMap[prefab];
        pool.Release(instance);
        _spawnedGameObjectsMap.Remove(instance);
    }

    public SpecialGameObjectPool<D> GetOrCreatePool(D prefab)
    {
        return _poolsMap.TryGetValue(prefab.gameObject, out SpecialGameObjectPool<D> pool) ? pool : CreatePool(prefab);
    }

    public SpecialGameObjectPool<D> CreatePool(D prefab, PoolSettings settings = null)
    {
        var newPool = new SpecialGameObjectPool<D>(prefab, settings ?? _defaultSettings, );
        _poolsMap.Add(prefab.gameObject, newPool);
        return newPool;
    }
}
