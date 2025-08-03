using System.Collections.Generic;
using UnityEngine;

public interface IMiniMapUpdate
{
    public void UpdateMiniMap(Dictionary<Vector2, RoomData> map, Vector2 currentRoomPosition);
}
