using UnityEngine;
using Zenject;

public class PoopFactory: IFactory
{
    private GameObject poopPrefab;
    private DiContainer container;

    [Inject]
    public void Construct(DiContainer container, GameObject poopPrefab)
    {
        this.poopPrefab = poopPrefab;
        this.container = container;
    }
    
    public GameObject Create(Vector2 position)
    {
        var poop = container.InstantiatePrefab(poopPrefab, position, Quaternion.identity, null);
        return poop;
    }
}
