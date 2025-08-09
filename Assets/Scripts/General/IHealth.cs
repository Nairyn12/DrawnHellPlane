using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public float HealthCurrent
    {
        get; set;
    }

    public float HealthMax
    {
        get; set;
    }

    public void Damage(float damage);
}
