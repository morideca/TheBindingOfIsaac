using UnityEngine;
using Zenject;

public class RoomDestroyer : IRoomDestroyer
{
    private RoomObjects roomObjects;
    
    [Inject]
    public void Construct(RoomObjects roomObjects)
    {
        this.roomObjects = roomObjects;
    }

    public void DestroyPreviousRoom()
    {
        foreach (var other in roomObjects.PreviousOthers)
        {
            Object.Destroy(other);
        }

        foreach (var door in roomObjects.PreviousDoors)
        {
            Object.Destroy(door);
        }
        
    }
}
