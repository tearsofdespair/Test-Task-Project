using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEnemyDestroyer : MonoBehaviour
{
    [SerializeField] float EnemyLifeTime;
    private ObjectPoolService _service;
    private void Start()
    {
        _service = new ObjectPoolService(new PoolSettings());
    }

    IEnumerator DestroyObject(GameObject obj)
    {
        yield return new WaitForSeconds(EnemyLifeTime);
        _service.Despawn(obj);
    }

    public void Destroy(GameObject obj)
    {
        StartCoroutine(DestroyObject(obj));
    }

}
