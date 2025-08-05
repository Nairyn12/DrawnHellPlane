using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    [SerializeField] private List<Transform> _guns;
    [SerializeField] private List<GameObject> _bullets;
    [SerializeField] private int _shootingMode;
    [SerializeField] private float _shootDelay;
    [SerializeField] private bool _isShoot;
    [SerializeField] private float _shootSpeed;

    public int ShootingMode 
    { 
        get => _shootingMode; 
        set => _shootingMode = value; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_isShoot)
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
                Debug.Log("—“–≈Àﬂ≈Ã: " + _bullets[i].name);
            }
            else
            {
                mode++;
            }
        }

        for (int i = 0; i < mode; i++)
        {
            Debug.Log("”¡–¿ÕŒ: " + _bullets[0].name);
            _bullets.Remove(_bullets[0]);
            //Debug.Log("”¡–¿ÕŒ–≈∆»Ã: " + mode);                   
        }

        _isShoot = true;
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
            Debug.Log("ƒÓ·‡‚ÎÂÌÓ: " + bullet.name);
            bullet.SetActive(false);
        }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_shootDelay);

        _isShoot = false;
    }


}
