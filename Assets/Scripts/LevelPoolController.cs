using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelPoolController : MonoBehaviour
{
    private SpecialObjectPoolService<Level> _poolService;
    private List<Level> _levels;
    private System.Random _random = new System.Random();
    private Level _lastLevel;
    private Level _preLastLevel;
    private Level _newLevel;
    private Transform _spawnPosition;

    [Inject]
    public void Constsruct(SpecialObjectPoolService<Level> service, List<Level> levels, Transform spawnPoint)
    {
        _poolService = service;
        _levels = levels;
        _spawnPosition = spawnPoint;
    }

    private void Awake()
    {
        _lastLevel = _poolService.Spawn(_levels[1]);
        _lastLevel.transform.position = new Vector3(-27f, -0.6f, 20);
        _preLastLevel = _poolService.Spawn(_levels[0]);
        _preLastLevel.transform.position = new Vector3(0, -0.6f, 20);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("NextLevel"))
        {
            _newLevel = _poolService.Spawn(_levels[_random.Next(0, _levels.Count)]);
            _newLevel.transform.position = _spawnPosition.position;
            _poolService.Despawn(_lastLevel);
            _lastLevel = _preLastLevel;
            _preLastLevel = _newLevel;
        }
    }
}
