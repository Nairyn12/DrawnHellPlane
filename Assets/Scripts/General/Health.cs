using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthCurrent;
    [SerializeField] private float _healthMax;
    [SerializeField] private int scale;

    public UnityEvent _death;

    private Explose _explose;

    public float HealthCurrent { get => _healthCurrent; }
    public float HealthMax { get => _healthMax; set => _healthMax = value; }

    private void Start()
    {
        _explose = FindAnyObjectByType<Explose>();
    }

    public void Damage(float damage)
    {
        if (damage < _healthCurrent)
            _healthCurrent -= damage;
        else
        {
            _healthCurrent = 0.0f;
            _explose.SetExplosion(scale, transform.position);
            _death?.Invoke();
        }
    }

    public void Healing(float heal)
    {
        if (heal + _healthCurrent < _healthMax)
            _healthCurrent += heal;
        else
            _healthCurrent = _healthMax;

    }
}
