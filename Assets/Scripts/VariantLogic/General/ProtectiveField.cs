using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ProtectiveField : MonoBehaviour, IProtectiveField
{
    [SerializeField] private SerializableFloatReactiveProperty _fieldHealth = new SerializableFloatReactiveProperty();
    [SerializeField] private HealthSystem _healthSystem;
    [SerializeField] private GameObject _field;

    public ReactiveProperty<float> FieldHealth { get => _fieldHealth; set => _fieldHealth = (SerializableFloatReactiveProperty)value; }

    [ContextMenu("FIELD")]
    public void FieldOn()
    {
        _field.SetActive(true);
        _healthSystem.Initialize(_fieldHealth.Value, _fieldHealth.Value);        
    }
}
