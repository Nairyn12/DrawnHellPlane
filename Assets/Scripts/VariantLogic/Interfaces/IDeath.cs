using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDeath
{
    public event Action OnDeath;
}
