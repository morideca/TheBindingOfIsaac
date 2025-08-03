using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomObjects
{
    public event Action<List<GameObject>> OnNewDoorsCreated;
    public List<GameObject> PreviousDoors { get; private set; } = new();
    public List<GameObject> Doors { get; private set; } = new();
    
    public List<GameObject> PreviousOthers { get; private set; } = new();
    public List<GameObject> Others { get; private set;} = new();

    public void SetDoors(List<GameObject> doors)
    {
        if (Doors.Count > 0)
        {
            PreviousDoors.Clear();
            foreach (var door in Doors)
            {
                PreviousDoors.Add(door);
            }
        }
        Doors.Clear();
        foreach (var door in doors)
        {
            Doors.Add(door);
        }
        
        OnNewDoorsCreated?.Invoke(Doors);
    }

    public void SetOthers(List<GameObject> others)
    {
        if (Others.Count > 0)
        {
            PreviousOthers.Clear();
            foreach (var other in Others)
            {
                PreviousOthers.Add(other);
            }
        }
        Others.Clear();
        foreach (var other in others)
        {
            Others.Add(other);
        }
    }
}
