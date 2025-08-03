using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected IMove move;
    private void Update()
    {
        move.MoveUpdate();
    }
}
