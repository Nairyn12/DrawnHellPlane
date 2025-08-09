using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField] private ViewModelPlayer _view;
    [SerializeField] private TMP_Text _scoreText;

    private void Awake()
    {
        _view.onChangedScore += RewriteScore;
    }

    public void RewriteScore()
    {
        Debug.Log("Обновляем данные в UI " + _view.Score);
        _scoreText.text = "Score: " + _view.Score;
    }
}
