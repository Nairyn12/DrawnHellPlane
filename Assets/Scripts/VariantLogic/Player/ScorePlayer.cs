using UniRx;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScore", menuName = "Game/PlayerScore")]
public class ScorePlayer : ScriptableObject
{
    [SerializeField] private FloatReactiveProperty _score = new FloatReactiveProperty();

    public IReadOnlyReactiveProperty<float> ScoreChanged => _score;

    public void Initialize(float initialScore)
    {
        _score.Value = initialScore;
    }

    public void TakeScore(float score)
    {
        Debug.Log("Score: " + score);
        _score.Value += score;
    }
}