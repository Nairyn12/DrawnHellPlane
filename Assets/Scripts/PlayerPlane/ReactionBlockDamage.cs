using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionBlockDamage : MonoBehaviour
{
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void DamageAnimation()
    {
        _anim.SetTrigger("Damage");
    }
}
