using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class TransitionBetweenRooms: IOnEnterRoomAction
{
    private IRoomBuilder roomBuilder;
    private IRoomDestroyer roomDestroyer;
    private CameraMove cameraMove;
    private ITeleportPlayer playerTeleport;
    private DoorsManager doorsManager;

    private List<GameObject> doors;

    private GameObject player;

    [Inject]
    public void Construct(IRoomBuilder roomBuilder, IRoomDestroyer roomDestroyer, CameraMove cameraMove, ITeleportPlayer playerTeleport
        ,DoorsManager doorsManager)
    {
        this.roomBuilder = roomBuilder; 
        this.cameraMove = cameraMove;
        this.roomDestroyer = roomDestroyer;
        this.playerTeleport = playerTeleport;
        this.doorsManager = doorsManager;
    }
    
    public void OnChangeRoomAction(RoomData lastRoomData, RoomData currentRoomData)
    {
        var direction = currentRoomData.Position - lastRoomData.Position;
        
        BuildRoom(currentRoomData);
        TeleportPlayer(direction);
        MoveCamera(currentRoomData);
    }

    private void BuildRoom(RoomData currentRoomData)
    {
        roomBuilder.BuildRoom(currentRoomData);
    }

    private async void MoveCamera(RoomData currentRoomData)
    {
        Task movingCamera = cameraMove.MoveToPositionAsync(roomBuilder.newRoomPosition, 100);
        await Task.WhenAll(movingCamera);
        
        DestroyPreviousRoom();
        
        if (!currentRoomData.isCleared)
        {
            doorsManager.SwitchDoors();
        }
    }

    private void DestroyPreviousRoom()
    {
        roomDestroyer.DestroyPreviousRoom();
    }

    private void TeleportPlayer(Vector2 direction)
    {
        float distance = 0;
        if (direction == Vector2.up || direction == Vector2.down)
        {
            distance = 4f;
        }
        else if (direction == Vector2.left || direction == Vector2.right)
        {
            distance = 8f;
        }
        var position = new Vector2(player.transform.position.x + direction.x * distance, player.transform.position.y + direction.y * distance);
        playerTeleport.TeleportPlayer(position);
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
}
