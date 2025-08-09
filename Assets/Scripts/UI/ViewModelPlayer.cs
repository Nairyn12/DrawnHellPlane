using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModelPlayer : MonoBehaviour
{
    [SerializeField] private Health _healthPlayer;

    public Action onChangedHealth;
    public Action onChangedScore;
    public float HealthCurrent
    {
        get; set;
    }

    public float Score
    {
        get; set;
    }

    public void ChangeHealthFromPlayer()
    {
        HealthCurrent = _healthPlayer.HealthCurrent;
        onChangedHealth?.Invoke();
    }

    public void ChangeScore()
    {        
        Score = ScoreCount.Instance.Score;
        onChangedScore?.Invoke();
    }

}
