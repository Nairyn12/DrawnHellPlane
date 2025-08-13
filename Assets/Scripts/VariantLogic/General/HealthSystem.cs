using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IHealth
{
    [SerializeField] private FloatReactiveProperty currentHealth;
    [SerializeField] private FloatReactiveProperty maxHealth;
    
    public float CurrentHealth => currentHealth.Value;
    public float MaxHealth => maxHealth.Value;
    public ReactiveProperty<float> HealthChanged => currentHealth;
    public ReactiveProperty<float> MaxHealthChanged => maxHealth;

    public void Initialize(float initialHealth, float initialMaxHealth)
    {
        currentHealth.Value = initialHealth;
        maxHealth.Value = initialMaxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth.Value = Mathf.Clamp(currentHealth.Value - damage, 0, maxHealth.Value);
    }

    public void Heal(float amount)
    {
        currentHealth.Value = Mathf.Clamp(currentHealth.Value + amount, 0, maxHealth.Value);
    }

    public void IncreaseMaxHealth(float amount)
    {
        maxHealth.Value += amount;
        currentHealth.Value = maxHealth.Value; // Полное исцеление при увеличении максимального здоровья
    }
}
