using UnityEngine;

public class ForwardMover : MonoBehaviour, ICanMove2D
{
    [SerializeField] ScriptableFloat forwardSpeed;

    void Update()
    {
        MoveForward();
    }

    public void MoveBackward()
    {
        throw new System.NotImplementedException();
    }

    public void MoveForward()
    {
        if (forwardSpeed)
            transform.Translate(transform.up * forwardSpeed.Value * Time.deltaTime);
    }

    public void MoveLeft()
    {
        throw new System.NotImplementedException();
    }

    public void MoveRight()
    {
        throw new System.NotImplementedException();
    }
}
