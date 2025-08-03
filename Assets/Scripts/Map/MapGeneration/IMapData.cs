using System.Collections.Generic;
using UnityEngine;

public interface IMapData
{
    public Dictionary<Vector2, RoomData> MapData { get; }
}