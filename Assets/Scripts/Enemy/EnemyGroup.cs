using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGroup : MonoBehaviour
{
    private const int MinValue = 3;
    private const int MaxValue = 6;
    
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Player _player;

    private int _activeEnemies;

    public int ActiveEnemies => _activeEnemies;
    
    private void OnEnable()
    {
        ActivateEnemy();

        foreach (var enemy in _enemies)
        {
            enemy.IsDead += ReduceLiving;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.IsDead -= ReduceLiving;
        }
    }

    private void ActivateEnemy()
    {
        var count = Random.Range(MinValue, MaxValue);

        _activeEnemies = count;
        
        for (int i = 0; i < count; i++)
        {
            var index = Random.Range(0, _enemies.Length);

            if (_enemies[index].gameObject.activeSelf == true)
            {
                i--;
                continue;
            }
            _enemies[index].gameObject.SetActive(true);
        }
    }

    private void ReduceLiving()
    {
        _activeEnemies--;
            _player.RemoveTarget();
    }
}