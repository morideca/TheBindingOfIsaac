using UnityEngine;
using Zenject;

public class FactoriesInstaller: MonoInstaller
{
    public GameObject PoopPrefab;
    
    public override void InstallBindings()
    {
        BindPoopFabric();
    }

    private void BindPoopFabric()
    {
        PoopFactory poopFactory = new();
        Container
            .Bind<IFactory>()
            .FromInstance(poopFactory)
            .AsSingle()
            .WithConcreteId("Poop");
    }
}
