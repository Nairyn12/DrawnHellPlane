using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModelPlayer : MonoBehaviour
{
    [SerializeField] private Health _healthPlayer;

    public Action onChangedHealth;
    public float HealthCurrent
    {
        get; set;
    }

    public void ChangeHealthFromPlayer()
    {
        HealthCurrent = _healthPlayer.HealthCurrent;
        onChangedHealth?.Invoke();
    }

}
