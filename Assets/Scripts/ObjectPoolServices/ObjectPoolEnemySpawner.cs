using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    [SerializeField] List<Transform> SpawnPoints;
    [SerializeField] float TimeToSpawn;
    [SerializeField] ObjectPoolEnemyDestroyer Destroyer;

    private ObjectPoolService _service;
    private void Start()
    {
        _service = new ObjectPoolService(new PoolSettings());
        StartCoroutine(SpawnerUpdate());
    }

    IEnumerator SpawnerUpdate()
    {
        while (true)
        {
            Destroyer.Destroy(SpawnObject());
            yield return new WaitForSeconds(TimeToSpawn);
        }
    }

    private GameObject SpawnObject()
    {
        GameObject spawnedObject = _service.Spawn(Prefab);
        spawnedObject.transform.SetPositionAndRotation(GetRandSpawnPoint().position, spawnedObject.transform.rotation);
        return spawnedObject;
    }

    private Transform GetRandSpawnPoint()
    {
        return SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count)];
    }
}
