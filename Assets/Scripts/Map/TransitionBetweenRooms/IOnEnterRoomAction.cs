using UnityEngine;

public interface IOnEnterRoomAction
{
    public void OnChangeRoomAction(RoomData lastRoomData, RoomData currentRoomData);
    public void SetPlayer(GameObject player);
}
