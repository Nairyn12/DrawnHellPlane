using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathPlayer : MonoBehaviour
{
    public UnityEvent _onUIAfterDeath;
    
    public void Death(GameObject obj)
    {
        _onUIAfterDeath?.Invoke();
        obj.SetActive(false);
    }
}
