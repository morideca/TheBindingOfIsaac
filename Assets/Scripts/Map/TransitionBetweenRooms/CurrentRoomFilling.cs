using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomFilling
{
    private List<GameObject> doors = new();
    private List<GameObject> enemies = new();
    private RoomData roomData;
    
    public List<GameObject> GetDoors() => doors;
    public List<GameObject> GetEnemyInfo() => enemies;
    public RoomData GetRoomData() => roomData;

    public void SetDoors(List<GameObject> doors)
    {
        this.doors = doors;
    }

    public void SetEnemies(List<GameObject> enemies)
    { 
        this.enemies = enemies;   
    }

    public void SetRoomData(RoomData roomData)
    {
        this.roomData = roomData;
    }


}
