using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    IPoolObj poolObj;
    IDamager damager;

    private void Awake()
    {
        SetInterfaces();
    }

    private void OnEnable()
    {
        damager.OnDamage += OnDamaged;
    }

    private void OnDisable()
    {
        damager.OnDamage -= OnDamaged;
    }

    void SetInterfaces()
    {
        poolObj = GetComponent<IPoolObj>();
        damager = GetComponent<IDamager>();
    }

    void OnDamaged(int damage)
    {
        poolObj.Release();
    }

}