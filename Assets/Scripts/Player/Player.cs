using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _targets;
    
    public event Action AllEnemiesIsDead;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out EnemyGroup group))
        {
            _targets = group.ActiveEnemies;
        }
    }

    public void RemoveTarget()
    {
        if (_targets != 0)
            _targets--;
        
        if (_targets == 0)
        {
            AllEnemiesIsDead?.Invoke();
        }
    }
}