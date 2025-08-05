using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    public UnityEvent _return;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {            
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            _return?.Invoke();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {         
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        
        if (collision.gameObject.GetComponent<Health>())
        {
            collision.gameObject.GetComponent<Health>().Damage(_damage);
        }
        
        _return?.Invoke();
    }

    
}
