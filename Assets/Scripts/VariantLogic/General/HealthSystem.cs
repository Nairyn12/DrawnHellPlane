using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IHealth
{
    [SerializeField] private SerializableFloatReactiveProperty currentHealth = new SerializableFloatReactiveProperty();
    [SerializeField] private SerializableFloatReactiveProperty maxHealth = new SerializableFloatReactiveProperty();
    [SerializeField] private SerializableFloatReactiveProperty scoreForPlayer = new SerializableFloatReactiveProperty();

    public ReactiveProperty<float> HealthChanged => currentHealth;

    public ReactiveProperty<float> MaxHealthChanged { get => maxHealth; }
    public bool IsPlayerDestroy { get => _isPlayerDestroy; set => _isPlayerDestroy = value; }
    internal SerializableFloatReactiveProperty ScoreForPlayer { get => scoreForPlayer; set => scoreForPlayer = value; }

    private bool _isPlayerDestroy;

    public void Initialize(float initialHealth, float initialMaxHealth)
    {
        currentHealth.Value = initialHealth;
        maxHealth.Value = initialMaxHealth;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Урон: " + damage);
        currentHealth.Value = Mathf.Clamp(currentHealth.Value - damage, 0, maxHealth.Value);
    }

    public void Heal(float amount)
    {
        currentHealth.Value = Mathf.Clamp(currentHealth.Value + amount, 0, maxHealth.Value);
    }

    public void IncreaseMaxHealth()
    {        
        currentHealth.Value = maxHealth.Value; // Полное исцеление при увеличении максимального здоровья
    }

    public void SetMaxHealth(float newValue)
    {
        maxHealth.Value = newValue;
    }
}
