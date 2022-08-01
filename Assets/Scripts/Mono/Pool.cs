using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour, IPool
{
    [SerializeField] PoolObj poolPrefab;
    [SerializeField] int firstCreatedAmount=100;
    [SerializeField] int batchAmount=25;


    public Stack<IPoolObj> AvailableObjects { get; set; }

    void Awake()
    {
        AvailableObjects = new Stack<IPoolObj>();
        CreateBatch(firstCreatedAmount);
    }

    public void CreateBatch(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var poolObj = Instantiate(poolPrefab).GetComponent<PoolObj>();
            poolObj.gameObject.SetActive(false);
            AvailableObjects.Push(poolObj);
        }
    }

    public IPoolObj Get()
    {
        if (AvailableObjects.Count == 0)
            CreateBatch(batchAmount);
        var obj = AvailableObjects.Pop();
        OnGettingObject(obj);
        return obj;
    }

    public void Return(IPoolObj poolObj)
    {
        var obj = ((PoolObj)poolObj).gameObject;
        obj.SetActive(true);
    }

    public void OnGettingObject(IPoolObj poolObj)
    {
        var obj = ((PoolObj)poolObj).gameObject;
        obj.SetActive(true);
    }

    public void OnReturningObject(IPoolObj poolObj)
    {
        var obj = ((PoolObj)poolObj).gameObject;
        obj.SetActive(false);
    }
}
