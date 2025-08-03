using System.Collections.Generic;
using UnityEngine;

public interface IRoomBuilder
{
    public void BuildRoom(RoomData roomData);
    public Vector2 newRoomPosition { get; }
}
