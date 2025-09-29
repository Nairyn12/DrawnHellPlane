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
    [SerializeField] DropFromEnemy _drop;
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
            if (col.gameObject.CompareTag("BulletPlayer"))
            {
                _health.IsPlayerDestroy = true;
                col.gameObject.GetComponent<SimpleDamage>()._return?.Invoke();
            }
            else
            {
                _health.IsPlayerDestroy = false;
            }
            IDamageDealer damage = col.gameObject.GetComponent<IDamageDealer>();
            TakeDamage(damage.DamageAmount.Value);
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
                _health.IsPlayerDestroy = false;
            }

            if (!gameObject.CompareTag("ProtectiveField"))
            {
                Explose.Instance.SetExplosion(_scale, transform.position);
            }
            
            if (!gameObject.CompareTag("Player") && !gameObject.CompareTag("ProtectiveField"))
            {
                Debug.Log("------- " + this.gameObject.name + " " + this.gameObject.transform.position);
                _drop.DropHealthItem(this.gameObject.transform.position);
                OnObjectDestroyed.Invoke(this.gameObject);                
            }
            else
            {
                _playerDeath?.Invoke();
            }
        }
    }   
}
