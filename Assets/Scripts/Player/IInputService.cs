using System;
using UnityEngine;

public interface IInputService
{
    event Action<Vector2> OnFire;
    event Action<Vector2> OnMove;
}