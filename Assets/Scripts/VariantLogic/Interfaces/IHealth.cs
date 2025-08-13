using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IHealth
{
    float CurrentHealth { get; }
    float MaxHealth { get; }
    void Heal(float amount);
    ReactiveProperty<float> HealthChanged { get; }
    ReactiveProperty<float> MaxHealthChanged { get; }
}
