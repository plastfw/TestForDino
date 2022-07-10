using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(1,3)][SerializeField] private int _health;

    private Collider _collider;

    public int Health => _health;
    
    public event Action IsDead;
    public event Action TakeDamage;

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
        
        TakeDamage?.Invoke();

        if (_health <= 0)
        {
            _collider.enabled = false;
            IsDead?.Invoke();
        }
    }
}