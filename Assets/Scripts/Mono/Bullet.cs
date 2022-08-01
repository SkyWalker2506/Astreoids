using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    ICanMove2D canMove;
    IPoolObj poolObj;

    private void Awake()
    {
        SetInterfaces();
    }

    private void FixedUpdate()
    {
        MoveCheck();
    }

    void SetInterfaces()
    {
        canMove = GetComponent<ICanMove2D>();
        poolObj = GetComponent<IPoolObj>();
    }

    void MoveCheck()
    {
        if (canMove == null) return;
        canMove.MoveForward();
    }

}