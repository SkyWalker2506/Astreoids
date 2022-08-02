using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] ControlKeys controlKeys;
    ICanMove2D canMove;
    ICanTurn canTurn;
    ICanAttack canAttack;

    private void Awake()
    {
        SetInterfaces();
    }

    
    private void Update()
    {
        MoveCheck();
        AttackCheck();
    }

    void SetInterfaces()
    {
        canMove = GetComponent<ICanMove2D>();
        canTurn = GetComponent<ICanTurn>();
        canAttack = GetComponentInChildren<ICanAttack>();
    }


    void MoveCheck()
    {
        if (canMove == null) return;
        if (Input.GetKey(controlKeys.TurnLeftKey))
            canTurn.TurnLeft();
        if (Input.GetKey(controlKeys.TurnRightKey))
            canTurn.TurnRight();
        if (Input.GetKey(controlKeys.MoveForwardKey))
            canMove.MoveForward();
    }

    void AttackCheck()
    {
        if (canAttack == null) return;
        if (Input.GetKeyDown(controlKeys.ShotKey))
            canAttack.Attack();
    }

}