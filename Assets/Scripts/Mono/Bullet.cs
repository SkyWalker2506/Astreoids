using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    ICanMove2D canMove;

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
    }

    void MoveCheck()
    {
        if (canMove == null) return;
        canMove.MoveForward();
    }

}