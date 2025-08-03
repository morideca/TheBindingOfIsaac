using UnityEngine;
using Zenject;

public class PlayerTeleport : ITeleportPlayer
{
    private GameObject player;
    
    [Inject]
    public void Construct(IPlayerFactory factory)
    {
        factory.OnPlayerCreated += SetPlayer;
    }

    private void SetPlayer(GameObject player)
    {
     this.player = player;   
    }

    public void TeleportPlayer(Vector2 position)
    {
        player.transform.position = position;
    }
}
