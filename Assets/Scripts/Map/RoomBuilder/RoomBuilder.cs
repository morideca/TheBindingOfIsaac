using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoomBuilder : MonoBehaviour, IRoomBuilder
{
    [SerializeField]
    private GameObjectConstructions roomVariants;
    [SerializeField] 
    private WallsGO wallsGO;
    [SerializeField]
    private DoorBuilder doorBuilder;
    private RoomVariantBuilder roomVariantBuilder;
    private WallBuilder wallBuilder;
    private RoomObjects roomObjects;


    public Vector2 newRoomPosition { get; private set; } = Vector2.zero;
    

    [Inject]
    public void Construct(RoomObjects roomObjects)
    {
        this.roomObjects = roomObjects;
    }

    private void Awake()
    {
        roomVariantBuilder = new RoomVariantBuilder(roomVariants);
        wallBuilder = new WallBuilder(wallsGO);
    }
    
    public void BuildRoom(RoomData roomData)
    {
        Vector2 center = new Vector2(roomData.Position.x * 20, roomData.Position.y * 10);
        newRoomPosition = center;
        
        if (roomData.isCleared && roomData.ClearedRoom != null)
        {
            Instantiate(roomData.ClearedRoom, center, Quaternion.identity); // в clearedRoom сохраняется пройденная комната, чтобы сохранять
            //поврежденные объекты
        }
        else
        {
            var roomVariant = roomVariantBuilder.BuildObstacles(roomData, center);
            var walls = wallBuilder.BuildWalls(roomData.Type, center);
            var Doors = doorBuilder.BuildDoors(roomData, center);
            List<GameObject> otherObjects = new();
            otherObjects.Add(walls);
            otherObjects.Add(roomVariant); 
            
            roomObjects.SetDoors(Doors);
            roomObjects.SetOthers(otherObjects);
        }
    }
}
