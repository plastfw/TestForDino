using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Enemy _enemy;

    private void OnEnable()
    {
        _enemy = GetComponent<Enemy>();
        _enemy.TakeDamage += ChangeValue;
    }

    private void Start()
    {
        SetValue();
    }

    private void OnDisable()
    {
        _enemy.TakeDamage -= ChangeValue;
    }

    private void SetValue()
    {
        _slider.minValue = 0;
        _slider.maxValue = _enemy.Health;
        _slider.value = _slider.maxValue;
    }

    private void ChangeValue()
    {
        _slider.value--;

        if (_slider.value == _slider.minValue)
        {
            _slider.gameObject.SetActive(false);
        }
    }
}