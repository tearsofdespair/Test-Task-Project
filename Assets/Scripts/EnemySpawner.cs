using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    [SerializeField] List<Transform> SpawnPoints;
    [SerializeField] float TimeToSpawn;
    private void Start()
    {
        StartCoroutine(SpawnerUpdate());
    }

    IEnumerator SpawnerUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeToSpawn);
            Instantiate(Prefab, SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count)].position, Quaternion.identity);
            Debug.Log("skadlfjsk");
        }
    }
}
