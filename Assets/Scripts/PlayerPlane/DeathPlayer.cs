using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    
    public void Death(GameObject obj)
    {
        obj.SetActive(false);
    }
}
