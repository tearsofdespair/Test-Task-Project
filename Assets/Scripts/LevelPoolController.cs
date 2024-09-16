using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPoolController : MonoBehaviour
{
    private ObjectPoolService _poolService;
    private List<GameObject> _levels;
    private System.Random _random = new System.Random();
    private GameObject _lastLevel;
    private GameObject _preLastLevel;
    private GameObject _newLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("NextLevel"))
        {
            _newLevel = _poolService.Spawn(_levels[_random.Next(0, _levels.Count - 1)]);
            _poolService.Despawn(_lastLevel);
            _lastLevel = _preLastLevel;
            _preLastLevel = _newLevel;
        }
    }
}
