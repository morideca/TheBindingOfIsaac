using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DoorsManager
{
    private List<Door> doors;
    private List<Door> previousDoors;

    public event Action<Vector2> onPlayerEnteredDoor;
    
    [Inject]
    public void Construct(RoomObjects roomObjects)
    {
        roomObjects.OnNewDoorsCreated += OnNewDoorsCreated;
    }

    private void OnNewDoorsCreated(List<GameObject> newDoorsGO)
    {
        if (doors == null)
        {
            doors = new();
        }

        previousDoors = doors;
        doors.Clear();
        
        foreach (var doorGO in newDoorsGO)
        {
            if (doorGO.TryGetComponent<Door>(out var door))
            {
                door.OnPlayerEntered += OnPlayerEnteredDoor;
                doors.Add(door);
            }
        }
    }

    private void OnPlayerEnteredDoor(Vector2 direction)
    {
        UnsubscribeDoors(); 
        onPlayerEnteredDoor?.Invoke(direction);
    }

    public void SwitchDoors()
    {
        foreach (var door in doors)
        {
            door.SwitchDoor();
        }
    }

    private void UnsubscribeDoors()
    {
        if (previousDoors.Count > 0)
        {
            foreach (var door in previousDoors)
            {
                door.OnPlayerEntered -= OnPlayerEnteredDoor;
            }
        }
    }
}
