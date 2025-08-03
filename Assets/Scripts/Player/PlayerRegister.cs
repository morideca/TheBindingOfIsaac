using UnityEngine;
using Zenject;

public class PlayerRegister
{
    private DiContainer container;

    [Inject]
    public void Construct(DiContainer container)
    {
        this.container = container;
    }

    public void RegisterPlayer(GameObject player)
    {
        var playerController = player.GetComponent<PlayerController>();
        container.Inject(playerController);
        container.Bind<PlayerController>()
            .FromInstance(playerController)
            .AsSingle();
    }
}
