using System;
using UnityEngine;

public class InputHandler : MonoBehaviour, IInputService
{
    private const KeyCode MoveUp = KeyCode.W;
    private const KeyCode MoveDown = KeyCode.S;
    private const KeyCode MoveLeft = KeyCode.A;
    private const KeyCode MoveRight = KeyCode.D;
    
    private const KeyCode AttackUp = KeyCode.UpArrow;
    private const KeyCode AttackDown = KeyCode.DownArrow;
    private const KeyCode AttackLeft = KeyCode.LeftArrow;
    private const KeyCode AttackRight = KeyCode.RightArrow;

    public event Action<Vector2> OnFire;
    public event Action<Vector2> OnMove;

    private void Update()
    {
        HandleMoveInput();
        HandleFireInput();
    }

    private void HandleFireInput()
    {
        if (Input.GetKey(AttackUp) || Input.GetKey(AttackDown) || Input.GetKey(AttackLeft) || Input.GetKey(AttackRight))
        {
            Vector2 attackDir = Vector2.zero;
            if (Input.GetKey(AttackUp)) attackDir = Vector2.up;
            else if (Input.GetKey(AttackDown)) attackDir = Vector2.down;
            else if (Input.GetKey(AttackLeft)) attackDir = Vector2.left;
            else if (Input.GetKey(AttackRight)) attackDir = Vector2.right;
            OnFire?.Invoke(attackDir);
        }
    }

    private void HandleMoveInput()
    {
        Vector2 moveDir = Vector2.zero;
        if (Input.GetKey(MoveUp)) moveDir += Vector2.up;
        if (Input.GetKey(MoveDown)) moveDir += Vector2.down;
        if (Input.GetKey(MoveLeft)) moveDir += Vector2.left;
        if (Input.GetKey(MoveRight)) moveDir += Vector2.right;
        OnMove?.Invoke(moveDir.normalized);
    }
}
