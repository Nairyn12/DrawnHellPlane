using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingSpaceShipEnemys : MonoBehaviour
{
    [SerializeField]private float _maxBullet = 10;
    [SerializeField]private List<GameObject> _bullets;
    [SerializeField]private GameObject _guns;
    private float _shootSpeed = 3f;
    public IEnumerator Shooting()
    {
        int i;
        for (i = 0; i < _maxBullet; i++)
        {
            if (_bullets[i] != null)
            {
                Debug.Log("Стреляет враг");
                _bullets[i].SetActive(true);
                _bullets[i].transform.position = _guns.transform.position;
                _bullets[i].GetComponent<Rigidbody2D>().AddForce(_bullets[i].transform.up * _shootSpeed, ForceMode2D.Impulse);
            }
            yield return new WaitForSeconds(0.3f);
        }
        
        StartCoroutine(Shooting());
        if (i>=_maxBullet)
        {
            i = 0;
            StartCoroutine(Shooting());
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bool overlap = false;

        for (int i = 0; i < _bullets.Count; i++)
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
}

