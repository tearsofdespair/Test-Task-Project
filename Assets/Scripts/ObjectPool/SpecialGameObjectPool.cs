using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public class SpecialGameObjectPool<T> where T : Component
{
    private readonly T _prefab;
    private readonly PoolSettings _settings;
    private readonly ObjectPool<GameObject> _pool;
    private readonly Transform _parent;
    private readonly DiContainer _container;


    public SpecialGameObjectPool(T prefab, PoolSettings settings, DiContainer diContainer)
    {
        _prefab = prefab;
        _settings = settings;
        _pool = new ObjectPool<GameObject>(
            Create, OnGet, OnRelease, OnDestroy,
            _settings.CollectionCheck, _settings.Capacity, _settings.MaxSize);
        _parent = new GameObject($"GameObject Pool <{_prefab.name}>").transform;
        _container = diContainer;
    }

    public int MaxSize => _settings.MaxSize;
    public int CountAll => _pool.CountAll;
    public int CountActive => _pool.CountActive;
    public int CountInactive => _pool.CountInactive;

    public GameObject Get()
    {
        return _pool.Get();
    }

    public void Release(GameObject instance)
    {
        _pool.Release(instance);
    }

    public void Clear()
    {
        _pool.Clear();
    }
    public void Dispose()
    {
        _pool.Dispose();
        Object.Destroy(_parent.gameObject);
    }

    private GameObject Create()
    {
        return _container.InstantiatePrefab(_prefab);
    }

    private void OnGet(GameObject instance)
    {
        instance.transform.SetParent(null);
        instance.gameObject.SetActive(true);
    }

    private void OnRelease(GameObject instance)
    {
        instance.transform.SetParent(_parent);
        instance.gameObject.SetActive(false);
    }

    private void OnDestroy(GameObject instance)
    {
        Object.Destroy(instance);
    }
}
