using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKidMoving : MonoBehaviour
{
    [SerializeField] private float _floatAmplitude = 1.0f;
    [SerializeField] private float _floatFrequency = 5f;
    [SerializeField] private float _rotationSpeed = 30f;

    private Vector3 _startPosition;

    private void Start()
    {         
        _startPosition = transform.position;
    }

    private void Update()
    {
        // Плавное парение в воздухе
        FloatAnimation();
        //RotateAnimation();
    }

    private void FloatAnimation()
    {
        float newY = _startPosition.y + Mathf.Sin(Time.time * _floatFrequency) * _floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void RotateAnimation()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }

}
