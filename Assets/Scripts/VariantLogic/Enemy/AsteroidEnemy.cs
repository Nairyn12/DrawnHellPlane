using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidEnemy : MonoBehaviour, IDamageDealer
{
    [SerializeField] private SerializableFloatReactiveProperty _damage = new SerializableFloatReactiveProperty();

    public ReactiveProperty<float> DamageAmount => _damage;

    public UnityEvent _return;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            _return?.Invoke();
        }
    }

    public void SetDamage(float newValue)
    {
        _damage.Value = newValue;
    }
}
