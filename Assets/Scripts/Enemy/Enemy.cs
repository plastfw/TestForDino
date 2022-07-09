using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(1,3)][SerializeField] private int _health;

    private Collider _collider;
    
    public event Action IsDead;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Bullet bullet))
        {
            ApplyDamage();
        }
    }

    private void ApplyDamage()
    {
        _health--;

        if (_health <= 0)
        {
            IsDead?.Invoke();
            _collider.enabled = false;
        }
    }
}