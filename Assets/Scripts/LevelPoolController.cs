using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelPoolController : MonoBehaviour
{
    private ObjectPoolService _poolService = new ObjectPoolService(new PoolSettings());
    public List<GameObject> _levels;
    private System.Random _random = new System.Random();
    private GameObject _lastLevel;
    private GameObject _preLastLevel;
    private GameObject _newLevel;
    [SerializeField] public Transform SpawnPosition;
    
    private void Awake()
    {
        _lastLevel = _poolService.Spawn(_levels[1]);
        _lastLevel.transform.position = new Vector3(-26.8f, 0, 11.45f);
        _preLastLevel = _poolService.Spawn(_levels[0]);
        _preLastLevel.transform.position = new Vector3(0, 0, 11.45f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("NextLevel"))
        {
            _newLevel = _poolService.Spawn(_levels[_random.Next(0, _levels.Count - 1)]);
            _newLevel.transform.position = SpawnPosition.position;
            _poolService.Despawn(_lastLevel);
            _lastLevel = _preLastLevel;
            _preLastLevel = _newLevel;
        }
    }
}
