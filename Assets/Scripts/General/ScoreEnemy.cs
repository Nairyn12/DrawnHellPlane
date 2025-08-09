using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEnemy : MonoBehaviour
{
    [SerializeField] private int _score;

    public int Score { get => _score; }

    public void ChangePlayerScore()
    {        
        ScoreCount.Instance.ChangeScore(_score);
    }
}
