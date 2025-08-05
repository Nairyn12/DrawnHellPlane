using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Asteriod : MonoBehaviour
{
    [SerializeField] private float _damage;

    public UnityEvent _return;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            _return?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Столкновение! " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Урон! " + collision.gameObject.name);
            collision.gameObject.GetComponent<Health>().Damage(_damage);
        }
    }
}
