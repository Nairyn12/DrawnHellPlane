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
    [SerializeField] private float _delayBlockDamage;
    [SerializeField] private bool _isHealthChange;

    public UnityEvent _damageReaction;
    public UnityEvent _OnChangeHealth;
    public UnityEvent _death;

    private Explose _explose;

    public float HealthCurrent { get => _healthCurrent; }
    public float HealthMax { get => _healthMax; set => _healthMax = value; }

    private void Start()
    {
        _isHealthChange = false;
        _explose = FindAnyObjectByType<Explose>();
        _OnChangeHealth?.Invoke();
    }

    public void Damage(float damage)
    {
        if (damage < _healthCurrent && !_isHealthChange)
        {
            _healthCurrent -= damage;
            _damageReaction?.Invoke();            
        }
        else if (damage >= _healthCurrent && !_isHealthChange)
        {
            _healthCurrent = 0.0f;
            _explose.SetExplosion(scale, transform.position);
            _death?.Invoke();
        }
        _OnChangeHealth?.Invoke();
    }

    public void Healing(float heal)
    {
        if (heal + _healthCurrent < _healthMax)
            _healthCurrent += heal;
        else
            _healthCurrent = _healthMax;

        _OnChangeHealth?.Invoke();
    }

    public void BlockUnBlockDamage(bool flag)
    {
        _isHealthChange = flag;
    }

    public void BlockDamageAndDelay()
    {
        _isHealthChange = true;
        StartCoroutine(DelayBlockDamage());
    }

    IEnumerator DelayBlockDamage()
    {
        yield return new WaitForSeconds(_delayBlockDamage);
        BlockUnBlockDamage(false);
    }
}
