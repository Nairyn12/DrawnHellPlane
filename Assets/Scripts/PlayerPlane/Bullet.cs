using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
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
        _return?.Invoke();
    }
}
