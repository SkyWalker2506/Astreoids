using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Damagable : MonoBehaviour,IDamagable
{
    public Action<int> OnDamaged { get; set; }

    public void ApplyDamage(int damage)
    {
        OnDamaged?.Invoke(damage);
    }
}
