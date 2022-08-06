using System;
using UnityEngine;

public class Astreoid : MonoBehaviour
{
    IDamagable damagable;
    IPoolObj poolObj;
    public int CurrentLevel;
    public static Action<Astreoid> OnDestroyed;

    void Awake()
    {
        poolObj = GetComponent<IPoolObj>();
        damagable = GetComponent<IDamagable>();
    }

    private void OnEnable()
    {
        if (damagable != null)
            damagable.OnDamaged += OnDamaged;
    }

    private void OnDisable()
    {
        if (damagable != null)
            damagable.OnDamaged -= OnDamaged;
    }

    void OnDamaged(int value)
    {
        Destroy();
    }

    void Destroy()
    {
        OnDestroyed?.Invoke(this);
        poolObj.Release();
    }
}