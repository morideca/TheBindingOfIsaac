using System;
using UnityEngine;

public interface IPlayerFactory
{
    public event Action<GameObject> OnPlayerCreated;
    public void Create();
}
