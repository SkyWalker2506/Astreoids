using System;
using UnityEngine;

public class Astreoid : MonoBehaviour
{
    IDamagable damagable;
    IPoolObj poolObj;
    [SerializeField] AstreoidSize sizeList;
    public int CurrentLevel;
    public static Action<Astreoid> OnDestroyed;

    void Awake()
    {
        damagable = GetComponent<IDamagable>();
    }

    private void Start()
    {
        SetAstreoid();
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

    void SetAstreoid()
    {
        transform.localScale = Vector3.one * sizeList.Sizes[Mathf.Clamp(CurrentLevel, 0, sizeList.Sizes.Length-1)];
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