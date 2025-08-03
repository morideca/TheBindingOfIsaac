using System;
using System.Collections.Generic;
using UnityEngine;

public enum RoomType
{
    Small,
    Medium,
    Treasure,
    Start,
    Boss
}
public class RoomData 
{
    public Vector2 Position { get; private set; }
    public RoomType Type { get; private set; }
    
    public bool HasOneDoor { get; private set; } = false;
    public int obstacleVariant { get; private set; } = -1;

    public Dictionary<Vector2, RoomType> Doors { get; private set; } = new();

    public bool isDiscovered = false;
    public bool isCleared;
    public GameObject ClearedRoom;

    public RoomData(Vector2 pos, RoomType t)
    {
        Position = pos;
        Type = t;

        switch (t)
        {
            case RoomType.Small:
            case RoomType.Boss:
                isCleared = false;
                break;
            case RoomType.Medium:
                break;
            case RoomType.Treasure:
            case RoomType.Start:
                isCleared = true;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(t), t, null);
        }
    }

    public void SetVariantOfRoom(int variantOfRoom)
    {
        this.obstacleVariant = variantOfRoom;
    }

    public void SetDoors(Dictionary<Vector2, RoomType> doors)
    {
        foreach (var door in doors)
        {
            Doors.Add(door.Key, door.Value);
        }
    }

    public void AddDoor(Vector2 pos, RoomType t)
    {
        Doors.Add(pos, t);
    }
}
