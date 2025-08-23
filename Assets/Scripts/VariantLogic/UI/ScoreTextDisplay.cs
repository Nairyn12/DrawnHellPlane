using TMPro;
using UnityEngine;
using UniRx;

public class ScoreTextDisplay : MonoBehaviour
{
    [SerializeField] ScorePlayer _score;
    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        // ������������� �� ��������� ��������
        _score.ScoreChanged
            .Subscribe(score => _scoreText.text = $"Score: {score:F1}")
            .AddTo(this); // �������������� ������� ��� ����������� ������� 
    }

}
