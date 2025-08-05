using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaneMove : MonoBehaviour
{
    [SerializeField] private Transform _moveTarget;
    
    private Rigidbody2D _moveRigidbody;

    private void Start()
    {
        _moveRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }


    private void FixedUpdate()
    {
        _moveRigidbody.MovePosition(Vector3.Lerp(transform.position, _moveTarget.position, 0.1f));
    }
}
