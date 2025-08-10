using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingPlayer : MonoBehaviour
{
    [SerializeField] private InputActionReference _shootActionRef;
    [SerializeField] private List<Transform> _guns;
    [SerializeField] private List<GameObject> _bullets;
    [SerializeField] private int _shootingMode;
    [SerializeField] private float _shootDelay;
    [SerializeField] private bool _isShootStart;
    [SerializeField] private bool _isShootEnd;
    [SerializeField] private float _shootSpeed;

    public int ShootingMode 
    { 
        get => _shootingMode; 
        set => _shootingMode = value; 
    }

    private void OnEnable()
    {
        _shootActionRef.action.Enable();
        _shootActionRef.action.performed += OnShootPerformed;
        _shootActionRef.action.canceled += OnShootCanceled;
    }

    private void OnDisable()
    {
        _shootActionRef.action.performed -= OnShootPerformed;
        _shootActionRef.action.canceled -= OnShootCanceled;
        _shootActionRef.action.Disable();
    }

    private void OnShootPerformed(InputAction.CallbackContext context)
    {
        _isShootStart = true;
        Debug.Log("Стрелять!");
        // Вы можете вызвать метод выстрела или запустить анимацию
    }

    private void OnShootCanceled(InputAction.CallbackContext context)
    {
        _isShootStart = false;
        Debug.Log("Стоп стрельба!");
    }

    private void Update()
    {
        if (_isShootStart && !_isShootEnd)
        {
            Shoot(_shootingMode);
        }       
    }

    public void Shoot(int mode)
    {
        for(int i = 0; i < mode; i++)
        {
            if (_bullets[i] != null)
            {
                _bullets[i].SetActive(true);
                _bullets[i].transform.position = _guns[i].transform.position;
                _bullets[i].GetComponent<Rigidbody2D>().AddForce(_bullets[i].transform.up * _shootSpeed, ForceMode2D.Impulse);               
            }
            else
            {
                mode++;
            }
        }

        for (int i = 0; i < mode; i++)
        {            
            _bullets.Remove(_bullets[0]);            
        }

        _isShootEnd = true;
        StartCoroutine(ShootDelay());

    }

    public void ReturnBullet(GameObject bullet)
    {
        bool overlap = false;

        for(int i = 0; i < _bullets.Count; i++)
        {
            if (_bullets[i].name == bullet.name)
            {
                overlap = true;
            }
        }

        if (!overlap)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            bullet.transform.position = transform.position;
            _bullets.Add(bullet);            
            bullet.SetActive(false);
        }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_shootDelay);

        _isShootEnd = false;
    }


}
