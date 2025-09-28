using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class FieldSystem : MonoBehaviour, IProtectiveField
{
    [SerializeField] private GameObject _field;

    public ReactiveProperty<float> FieldDuration { get; set; }

    public void FieldOn(float time)
    {


    }
}
