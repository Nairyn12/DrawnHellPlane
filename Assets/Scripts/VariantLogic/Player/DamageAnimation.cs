using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageAnimation : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private DamageController _damage;

    public void Damage()
    {
        _anim.SetTrigger("Damage");
        _damage.IsDamage = true;
        StartCoroutine(DelayBlockDamage());
    }

    IEnumerator DelayBlockDamage()
    {
        yield return new WaitForSeconds(1.0f);

        _damage.IsDamage = false;
    }
}
