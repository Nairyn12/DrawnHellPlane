using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;

public class DamageController : MonoBehaviour, IDamageable
{
    [SerializeField] private HealthSystem _health;

    private void Start()
    {
        _health = GetComponent<HealthSystem>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<IDamageDealer>() != null)
        {
            IDamageDealer damage = col.gameObject.GetComponent<IDamageDealer>();
            TakeDamage(damage.DamageAmount);
        }
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);

        if (_health.CurrentHealth <= 0)
        {
            
        }
    }
}
