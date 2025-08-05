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
            Debug.Log(gameObject.name + " вышел из триггера " + collision.gameObject.name);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            _return?.Invoke();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject.name + " столкнулся с " + collision.gameObject.name);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        _return?.Invoke();
    }

    
}
