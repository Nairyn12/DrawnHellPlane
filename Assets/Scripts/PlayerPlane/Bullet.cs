using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    public UnityEvent _return;

    public float Damage { get => _damage; set => _damage = value; }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            ReturnInPool();  
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.GetComponent<Health>())
        {
            ReturnInPool();
        }


        //    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        
        //if (collision.gameObject.GetComponent<Health>())
        //{
        //    Health health = collision.gameObject.GetComponent<Health>();
        //    DateTime currentTime = DateTime.Now;

        //    Debug.Log("---Пуля " + gameObject.name + " от игрока по объекту " + collision.gameObject.name + " " +
        //        currentTime.Hour + " " + currentTime.Minute + " " + currentTime.Second + " " + currentTime.Millisecond);            
        //    Debug.Log("Здоровье " + health.HealthCurrent); 

        //    if (gameObject.CompareTag("BulletPlayer") && health.HealthCurrent <= _damage && health.HealthCurrent > 0)
        //    {                
        //        health.CountPlayerDamage++;                
        //    }
            
        //    health.Damage(_damage);            
        //}
        
        //_return?.Invoke();
    } 
    
    public void ReturnInPool()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        _return?.Invoke();
    }
}
