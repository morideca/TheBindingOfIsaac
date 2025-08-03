using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Map: IMapData, IMapDataGenerator, IMapDataChanges
{
    public event Action<Dictionary<Vector2, RoomData>, Vector2> OnChangesOnTheMap;
    public event Action<RoomData, RoomData> OnPlayerEnteredRoom;
    
    public Dictionary<Vector2, RoomData> MapData { get; private set; }
    
    private Vector2 currentRoomPos;
    
    private readonly MapDataGenerator mapDataDataGenerator = new();

    private DoorsManager doorsManager;

    [Inject]
    public void Construct(DoorsManager doorsManager)
    {
        this.doorsManager = doorsManager;
        doorsManager.onPlayerEnteredDoor += SwapCurrentRoom;
    }
    
    public void GenerateMap(int roomCount)
    {
        MapData = mapDataDataGenerator.GenerateMap(roomCount);
        RevealRooms();
        SetStartRoomAsCurrent();
    }

    private void SetStartRoomAsCurrent()
    {
        currentRoomPos = Vector2.zero;
        OnPlayerEnteredRoom?.Invoke(MapData[currentRoomPos], MapData[currentRoomPos]);
    }

    private void SwapCurrentRoom(Vector2 direction)
    {
        var lastRoomPos = currentRoomPos;
        currentRoomPos += direction;
        RevealRooms();
        OnPlayerEnteredRoom?.Invoke(MapData[lastRoomPos], MapData[currentRoomPos]);
    }

    private void RevealRooms()
    {
        if (MapData.TryGetValue(currentRoomPos, out RoomData room))
        {
            // room.isVisited = true;
            room.isDiscovered = true;
            
            Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
            foreach (var dir in directions)
            {
                Vector2 neighbor = currentRoomPos + dir;
                if (MapData.ContainsKey(neighbor))
                    MapData[neighbor].isDiscovered = true;
            }
        }
        OnChangesOnTheMap?.Invoke(MapData, currentRoomPos);
    }
}
