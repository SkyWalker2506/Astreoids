using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidManager : MonoBehaviour
{
    IPool astreoidPool;
    [SerializeField] AstreoidSize sizeList;
    [SerializeField] ScriptableFloat astreoidCreateInterval;

    private void Awake()
    {
        astreoidPool = GetComponent<IPool>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(CreateRandomAstreoid), 1, astreoidCreateInterval.Value);
    }

    private void OnEnable()
    {
        Astreoid.OnDestroyed += OnAstreoidDestroyed;   
    }

    void OnAstreoidDestroyed(Astreoid destroyedAstreoid)
    {
        if (destroyedAstreoid.CurrentLevel == 0) return;
        for (int i = 0; i < 2; i++)
        {
            var astreoid =  CreateAstreoid(destroyedAstreoid.CurrentLevel - 1, destroyedAstreoid.transform.position, destroyedAstreoid.transform.rotation).transform;
            astreoid.Rotate(-35 + 70 * i, 0, 0);
            astreoid.Translate(astreoid.forward*.5f, Space.World);
        }
    }

    Astreoid CreateAstreoid(int astreoidLevel,Vector3 position,Quaternion rotation)
    {
        var astreoid=((MonoBehaviour)astreoidPool.Get()).GetComponent<Astreoid>();
        astreoid.CurrentLevel = astreoidLevel;
        astreoid.transform.position = position;
        astreoid.transform.rotation = rotation;
        SetAstreoid(astreoid);
        return astreoid;
    }

    void SetAstreoid(Astreoid astreoid)
    {
        astreoid.transform.localScale = Vector3.one * sizeList.Sizes[Mathf.Clamp(astreoid.CurrentLevel, 0, sizeList.Sizes.Length)];
    }

    void CreateRandomAstreoid()
    {
        RotateAstroid(CreateAstreoid(Random.Range(0, sizeList.Sizes.Length), EdgeManager.RandomEdgePosition(), Quaternion.identity).transform);
    }

    void RotateAstroid(Transform transform)
    {
        transform.LookAt(Spaceship.Instance.transform);
        transform.Rotate(Random.Range(-50,50), 0, 0);
    }
}
