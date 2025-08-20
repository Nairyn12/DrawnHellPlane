using TMPro;
using UnityEngine;
using UniRx;

public class HealthTextDisplay : MonoBehaviour
{
    [SerializeField] private HealthSystem _playerHealth;
    [SerializeField] private TMP_Text _healthText;

    private void Start()
    {
        // Подписываемся на изменения здоровья
        _playerHealth.HealthChanged
            .Subscribe(health => _healthText.text = $"Health: {health:F1}")
            .AddTo(this); // Автоматическая отписка при уничтожении объекта      
    }
}
