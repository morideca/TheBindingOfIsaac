using System;
using UnityEngine;

public abstract class AbstractAttack
{
    protected PlayerCharacteristics characteristics;
    
    public abstract TypeOfAttack Type { get; protected set; }
    public abstract void Attack(Transform gun, Vector2 dir, Vector2 playerVelocty);

    protected AbstractAttack(PlayerCharacteristics characteristics)
    {
        this.characteristics = characteristics;
    }
}
