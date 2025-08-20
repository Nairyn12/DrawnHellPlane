using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using System;
using UnityEngine.Events;

public class DamageController : MonoBehaviour, IDamageable
{
    [SerializeField] private int _scale;

    private HealthSystem _health;

    public event Action<GameObject> OnObjectDestroyed;

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
        _health.TakeDamage(damage);

        if (_health.HealthChanged.Value <= 0.0f)
        {
            if (_health.IsPlayerDestroy)
            {
                PlayerScore.TakeScore(_health.ScoreForPlayer.Value);
            }
            Explose.Instance.SetExplosion(_scale, transform.position);
            OnObjectDestroyed.Invoke(this.gameObject);
        }
    }
}
