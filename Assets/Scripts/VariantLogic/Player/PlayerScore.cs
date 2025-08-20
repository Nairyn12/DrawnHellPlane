using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public static class PlayerScore 
{
    [SerializeField] private static SerializableFloatReactiveProperty _score = new SerializableFloatReactiveProperty();

    public static ReactiveProperty<float> ScoreChanged => _score;

    public static void Initialize(float initialScore)
    {
        _score.Value = initialScore;
    }

    public static void TakeScore(float score)
    {
        Debug.Log("Score: " + score);
        _score.Value += score;
    }
}
