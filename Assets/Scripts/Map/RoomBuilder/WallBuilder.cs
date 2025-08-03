using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class WallBuilder
{
    private WallsGO wallsPrefabs;

    public WallBuilder(WallsGO wallsPrefabs)
    {
        this.wallsPrefabs = wallsPrefabs;
    }
    
    public GameObject BuildWalls(RoomType roomType, Vector2 center)
    {
        GameObject walls = wallsPrefabs.smallRoomPrefab;
        switch (roomType)
        {
            case RoomType.Small:
                walls = wallsPrefabs.smallRoomPrefab;
                break;
            case RoomType.Medium:
                walls = wallsPrefabs.mediumRoomPrefab;
                break;
            case RoomType.Treasure:
                break;
            case RoomType.Start:
                break;
            case RoomType.Boss:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(roomType), roomType, null);
        }
        var wallsGO = Object.Instantiate(walls, center, Quaternion.identity);
        return wallsGO;
    }
}
