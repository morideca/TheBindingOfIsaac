using System;
using System.Collections.Generic;
using UnityEngine;

public class DoorBuilder : MonoBehaviour
{
    [SerializeField] 
    private GameObject doorsOfSmallRoomTransform;

    [SerializeField] 
    private GameObject noDoorPrefab;
    [SerializeField] 
    private GameObject simpleDoorPrefab;
    [SerializeField]
    private GameObject treasureDoorPrefab;
    [SerializeField] 
    private GameObject bossDoorPrefab;

    private GameObject doorsTransformsGO;

    public List<GameObject> BuildDoors(RoomData roomData, Vector2 center)
    {
        List<GameObject> doors = null;
        switch (roomData.Type)
        {
            case RoomType.Small:
            case RoomType.Start:
            case RoomType.Treasure:
            case RoomType.Boss:
                doors = InstantiateSmallRoomDoors(roomData, center); 
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(roomData.Type), roomData.Type, null);
        }
        return doors;
    } 

    private List<GameObject> InstantiateSmallRoomDoors(RoomData roomData, Vector2 center)
    {
        List<GameObject> doors = new List<GameObject>();
        GameObject doorPrefab = null; 
        
        ReplaceDoorsTransforms(center);

        var doorsTransforms = doorsTransformsGO.GetComponent<DoorTransformsOfSimpleRoom>();

        var leftEmptyDoor = Instantiate(noDoorPrefab, doorsTransforms.LeftDoorTransform.transform);
        var rightEmptyDoor = Instantiate(noDoorPrefab, doorsTransforms.RightDoorTransform.transform);
        var topEmptyDoor = Instantiate(noDoorPrefab, doorsTransforms.TopDoorTransform.transform);
        var bottomEmptyDoor = Instantiate(noDoorPrefab, doorsTransforms.BottomDoorTransform.transform);

        List<GameObject> emptyDoors = new();
        emptyDoors.Add(leftEmptyDoor);
        emptyDoors.Add(rightEmptyDoor);
        emptyDoors.Add(topEmptyDoor);
        emptyDoors.Add(bottomEmptyDoor);
        
        foreach (var door in roomData.Doors)
        {
            if (door.Key == Vector2.left)
            {
                Destroy(leftEmptyDoor);
                doorPrefab = InstantiateDoor(door, doorsTransforms.LeftDoorTransform.transform);
            }
            else if (door.Key == Vector2.right)
            {
                Destroy(rightEmptyDoor);
                doorPrefab = InstantiateDoor(door, doorsTransforms.RightDoorTransform.transform);
            }
            else if (door.Key == Vector2.up)
            {
                Destroy(topEmptyDoor);
                doorPrefab = InstantiateDoor(door, doorsTransforms.TopDoorTransform.transform);
            }
            else if (door.Key == Vector2.down)
            {
                Destroy(bottomEmptyDoor);
                doorPrefab = InstantiateDoor(door, doorsTransforms.BottomDoorTransform.transform);
            }
            doors.Add(doorPrefab);
        }

        foreach (var emptyDoor in emptyDoors)
        {
            if (emptyDoor != null)
            {
                doors.Add(emptyDoor);
            }
        }
        
        return doors;
    }

    private void ReplaceDoorsTransforms(Vector2 center)
    {
        Destroy(doorsTransformsGO);
        doorsTransformsGO = Instantiate(doorsOfSmallRoomTransform, center, Quaternion.identity);
    }

    private GameObject InstantiateDoor(KeyValuePair<Vector2, RoomType> doorInfo, Transform transform)
    {
        GameObject doorGO = null;
        GameObject doorPrefab = simpleDoorPrefab;

        switch(doorInfo.Value)
        {
            case RoomType.Small:
                doorPrefab = simpleDoorPrefab;
                break;
            case RoomType.Medium:
                break;
            case RoomType.Treasure:
                doorPrefab = treasureDoorPrefab;
                break;
            case RoomType.Start:
                break;
            case RoomType.Boss:
                doorPrefab = bossDoorPrefab;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(doorInfo.Value), doorInfo.Value, null);
        }
        doorGO = Instantiate(doorPrefab, transform);
        doorGO.GetComponent<Door>().direction = doorInfo.Key;
        return doorGO;
    }
}