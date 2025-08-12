using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCount : MonoBehaviour
{
    public static ScoreCount Instance { get;  set; }   

    [SerializeField] private int _score;

    public int Score { get => _score; }

    public UnityEvent _onChangeScore;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        _score = 0;
        
    }

    private void Start()
    {
        _onChangeScore?.Invoke();
    }

    public void ChangeScore(int value)
    {        
        _score += value;
        _onChangeScore?.Invoke();
    }

}

  
