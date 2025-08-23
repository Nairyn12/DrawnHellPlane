using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthCurrent;
    [SerializeField] private float _healthMax;
    [SerializeField] private int scale;
    [SerializeField] private float _delayBlockDamage;
    [SerializeField] private bool _isHealthChange;
    [SerializeField] private bool _IsPlayerDestroy;
    [SerializeField] private int _countPlayerDamage;

    public UnityEvent _damageReaction;
    public UnityEvent _OnChangeHealth;
    public UnityEvent _OnChangeScore;
    public UnityEvent _death;

    private Explose _explose;
    private PolygonCollider2D _polygonCollider;

    public float HealthCurrent { get => _healthCurrent; set => _healthMax = value; }
    public float HealthMax { get => _healthMax; set => _healthMax = value; }
    public bool IsPlayerDestroy { get => _IsPlayerDestroy; set => _IsPlayerDestroy = value; }
    public int CountPlayerDamage { get => _countPlayerDamage; set => _countPlayerDamage = value; }
    public PolygonCollider2D PolygonCollider { get => _polygonCollider; set => _polygonCollider = value; }

    private void Start()
    {
        _isHealthChange = false;
        _explose = FindAnyObjectByType<Explose>();
        _OnChangeHealth?.Invoke();
        _polygonCollider = GetComponent<PolygonCollider2D>();
    }

    public void Damage(float damage)
    {
        if (damage < _healthCurrent && !_isHealthChange)
        {
            _healthCurrent -= damage;
            _damageReaction?.Invoke();
            _IsPlayerDestroy = false;
        }
        else if (damage >= _healthCurrent && !_isHealthChange && _healthCurrent > 0)
        {
            _healthCurrent = 0.0f;
            Debug.Log(gameObject.name + " " + transform.position);
            _explose.SetExplosion(scale, transform.position);            

            if(_IsPlayerDestroy)
            {
                DateTime currentTime = DateTime.Now;                
                Debug.Log("Уничтожили объект пулей от игрока! " + gameObject.name + " " + " время: " +
                    currentTime.Hour + " " + currentTime.Minute + " " + currentTime.Second + " " + currentTime.Millisecond);
                _OnChangeScore?.Invoke();
            }

            StartCoroutine(DelayAfterDeath());
            //_death?.Invoke();            
        }
        _OnChangeHealth?.Invoke();
    }

    public void Healing(float heal)
    {
        if (heal + _healthCurrent < _healthMax)
            _healthCurrent += heal;
        else
            _healthCurrent = _healthMax;

        _OnChangeHealth?.Invoke();
    }

    public void BlockUnBlockDamage(bool flag)
    {
        _isHealthChange = flag;
    }

    public void BlockDamageAndDelay()
    {
        _isHealthChange = true;
        StartCoroutine(DelayBlockDamage());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            DateTime currentTime = DateTime.Now;
            
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            
            //Debug.Log("Здоровье до урона" + _healthCurrent);
            //Debug.Log("---Пуля " + gameObject.name + " от игрока по объекту " + collision.gameObject.name + " " +
            //    currentTime.Hour + " " + currentTime.Minute + " " + currentTime.Second + " " + currentTime.Millisecond);           
            
            bullet.ReturnInPool();            

            if (collision.gameObject.CompareTag("BulletPlayer") && _healthCurrent <= bullet.Damage && _healthCurrent > 0)
            {
                IsPlayerDestroy = true;                
            }

            Damage(bullet.Damage);
        }
    }

    IEnumerator DelayBlockDamage()
    {
        yield return new WaitForSeconds(_delayBlockDamage);
        BlockUnBlockDamage(false);
    }

    IEnumerator DelayAfterDeath()
    {
        yield return new WaitForSeconds(0.1f);
        _death?.Invoke();
    }
}
