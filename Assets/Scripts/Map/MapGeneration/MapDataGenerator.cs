


using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class MapDataGenerator
{
    private Vector2 currentRoomPos = Vector2.zero;

    public Dictionary<Vector2, RoomData> GenerateMap(int roomCount)
    {
        Dictionary<Vector2, RoomData> rooms = new();

        rooms[currentRoomPos] = new RoomData(currentRoomPos, RoomType.Start);

        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

        for (int i = 0; i < roomCount - 1; i++)
        {
            var randomDirection = directions[Random.Range(0, directions.Length)];
            Vector2 newRoom = currentRoomPos + randomDirection;

            while (rooms.ContainsKey(newRoom))
            {
                newRoom = currentRoomPos + directions[Random.Range(0, directions.Length)];
            }

            RoomType type = RoomType.Small;
            if (i == roomCount - 2)
            {
                type = RoomType.Boss;
            }

            if (i == 1)
            {
                type = RoomType.Treasure;
            }

            rooms[newRoom] = new RoomData(newRoom, type); 
            
            if (type != RoomType.Treasure && type != RoomType.Boss)
            {
                currentRoomPos = newRoom;
            }
        }

        currentRoomPos = Vector2Int.zero;
        AddDoors(rooms);
        AddObstacles(rooms);
        return rooms;
    }

    public void AddDoors(Dictionary<Vector2, RoomData> mapData)
    {
   
        Vector2Int[] directions = new Vector2Int[]
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };

        foreach (var roomPosition in mapData.Keys)
        {
            Dictionary<Vector2, RoomType> doors = new();
            foreach (Vector2Int dir in directions)
            {
                Vector2 neighborPos = roomPosition + dir;
                if (mapData.ContainsKey(neighborPos))
                {
                    var neighbor = mapData[neighborPos];
                  
                    switch (mapData[roomPosition].Type)
                    {
                        case RoomType.Start:
                        case RoomType.Small:
                        case RoomType.Medium:
                            if (neighbor.Type != RoomType.Boss && neighbor.Type != RoomType.Treasure)
                            {
                                doors.Add(dir, neighbor.Type);
                            }
                            
                            break;
                        case RoomType.Treasure:
                        case RoomType.Boss:
                            if (doors.Count == 0 && neighbor.Type != RoomType.Boss && neighbor.Type != RoomType.Treasure)
                            {
                                doors.Add(dir, mapData[roomPosition].Type);
                                Vector2Int neighborDirection = -dir;
                                neighbor.AddDoor(neighborDirection, mapData[roomPosition].Type);
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            mapData[roomPosition].SetDoors(doors);
        }
    }

    private void AddObstacles(Dictionary<Vector2, RoomData> rooms)
    {
        foreach (var room in rooms.Values)
        {
            var obstacleVariant = Random.Range(0, 100);
            room.SetVariantOfRoom(obstacleVariant);
        }
    }

    private void AddEnemies()
    {
        
    }
}