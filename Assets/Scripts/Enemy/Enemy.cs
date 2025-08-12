using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
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
        if (collision.gameObject.GetComponent<Health>())
        {
            if (!collision.gameObject.CompareTag("BulletPlayer"))
            {
                collision.gameObject.GetComponent<Health>().IsPlayerDestroy = false;
            }

            collision.gameObject.GetComponent<Health>().Damage(_damage);
        }
    }
}
