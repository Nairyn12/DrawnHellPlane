using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IProtectiveField
{
    ReactiveProperty<float> FieldHealth { get; set; }

    void FieldOn(float time);
}
