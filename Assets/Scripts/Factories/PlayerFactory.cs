using System;
using UnityEngine;
using Zenject;

public class PlayerFactory: IPlayerFactory
{
    public event Action<GameObject> OnPlayerCreated;
    
    private GameObject playerPrefab;
    private DiContainer container;
    private PlayerRegister playerRegister;

    public PlayerFactory(GameObject playerPrefab)
    {
        this.playerPrefab = playerPrefab;
    }
    
    [Inject]
    public void Construct(DiContainer container, PlayerRegister playerRegister)
    {
        this.container = container;
        this.playerRegister = playerRegister;
    }



    public void Create()
    {
        var player = container.InstantiatePrefab(playerPrefab, Vector3.zero, Quaternion.identity, null);
        playerRegister.RegisterPlayer(player);
        OnPlayerCreated?.Invoke(player);
    }
}
