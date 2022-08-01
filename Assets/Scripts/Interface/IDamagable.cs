using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable 
{
    public Action<int> OnDamaged { get; set; }
}