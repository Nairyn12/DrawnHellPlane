using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IDamageDealer
{    
    ReactiveProperty<float> DamageAmount { get;}
}
