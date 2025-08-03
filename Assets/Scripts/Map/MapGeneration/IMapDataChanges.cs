using System;
using System.Collections.Generic;
using UnityEngine;

public interface IMapDataChanges
{
    public event Action<RoomData, RoomData> OnPlayerEnteredRoom;
    public event Action<Dictionary<Vector2, RoomData>, Vector2> OnChangesOnTheMap;
}
