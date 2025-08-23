using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using System;
using UnityEngine.Events;

public class DamageController : MonoBehaviour, IDamageable
{
    [SerializeField] private int _scale;
    [SerializeField] ScorePlayer _score;
    private HealthSystem _health;
    private bool _isDamage;

    public bool IsDamage { get => _isDamage; set => _isDamage = value; }

    public event Action<GameObject> OnObjectDestroyed;
    public UnityEvent _playerDamage;
    public UnityEvent _playerDeath;

    private void Start()
    {
        _health = GetComponent<HealthSystem>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<IDamageDealer>() != null)
        {
            IDamageDealer damage = col.gameObject.GetComponent<IDamageDealer>();
            TakeDamage(damage.DamageAmount.Value);
            if (col.gameObject.CompareTag("BulletPlayer"))
            {
                _health.IsPlayerDestroy = true;
                col.gameObject.GetComponent<SimpleDamage>()._return?.Invoke();
            }
            else
            {
                _health.IsPlayerDestroy = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (!_isDamage)
        {
            _health.TakeDamage(damage);
            _playerDamage?.Invoke();
        }     

        if (_health.HealthChanged.Value <= 0.0f)
        {
            if (_health.IsPlayerDestroy)
            {
                _score.TakeScore(_health.ScoreForPlayer.Value);
            }
            
            Explose.Instance.SetExplosion(_scale, transform.position);
            
            if (!gameObject.CompareTag("Player"))
            {
                OnObjectDestroyed.Invoke(this.gameObject);
            }
            else
            {
                _playerDeath?.Invoke();
            }
        }
    }
}
