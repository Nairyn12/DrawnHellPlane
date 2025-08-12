using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class TargetMoveController : MonoBehaviour
{
    [SerializeField] private float _speedTarget;

    [SerializeField] private InputActionReference _playerInput;

    private Vector2 _input;

    private void OnEnable()
    {
        _playerInput.action.Enable();
        _playerInput.action.performed += OnMovePerformed;
        _playerInput.action.canceled += OnMoveCanceled;
    }

    private void OnDisable()
    {
        _playerInput.action.performed -= OnMovePerformed;
        _playerInput.action.canceled -= OnMoveCanceled;
        _playerInput.action.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();        
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _input = Vector2.zero;
    }

    void Update()
    {        
        
        if (_input.x != 0.0f || _input.y != 0.0f)
        {
            transform.position += new Vector3(_input.x * _speedTarget * Time.deltaTime, _input.y * _speedTarget * Time.deltaTime);
        }       
    }
}
