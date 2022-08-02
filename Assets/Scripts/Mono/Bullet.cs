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

    void SetInterfaces()
    {
        poolObj = GetComponent<IPoolObj>();
        damager = GetComponent<IDamager>();

    }


}