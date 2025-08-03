using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class RoomVariantBuilder
{
    private GameObjectConstructions smallRoomVariantPrefab;

    public RoomVariantBuilder(GameObjectConstructions smallRoomVariantPrefab)
    {
        this.smallRoomVariantPrefab = smallRoomVariantPrefab;
    }

    public GameObject BuildObstacles(RoomData roomData, Vector2 center)
    {
        GameObject obstacles = null;
        switch (roomData.Type)
        {
            case RoomType.Small:
                var variantsCount = smallRoomVariantPrefab.ObstaclesGO.Count;
                while (roomData.obstacleVariant >= variantsCount)
                {
                    roomData.SetVariantOfRoom(roomData.obstacleVariant - variantsCount);
                }
                GameObject ObstacleObjects = smallRoomVariantPrefab.ObstaclesGO[roomData.obstacleVariant]; 
                obstacles = Object.Instantiate(ObstacleObjects, center, Quaternion.identity);
                break;
            case RoomType.Medium:
                break;
            case RoomType.Treasure: 
                break;
            case RoomType.Start:
                break;
            case RoomType.Boss:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(roomData.Type), roomData.Type, null);
        }
        return obstacles;
    }

}
