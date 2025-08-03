using System;
using UnityEngine;
using Zenject;

public class BootStrap : MonoBehaviour
{
    private IMapDataChanges mapDataChanges;
    private IMapDataGenerator mapDataGenerator;
    private IMiniMapUpdate miniMapUpdate;

    private IPlayerFactory playerFactory;
    
    private IOnEnterRoomAction onEnterRoomAction;
    
    [Inject]
    public void Construct(IPlayerFactory playerFactory, IMapDataGenerator iMapDataGenerator
        , IMapDataChanges iMapDataChanges, IMiniMapUpdate miniMapUpdate, IOnEnterRoomAction onEnterRoomAction)
    {
        this.playerFactory = playerFactory;
        mapDataChanges = iMapDataChanges;
        mapDataGenerator = iMapDataGenerator; 
        this.miniMapUpdate = miniMapUpdate;
        this.onEnterRoomAction = onEnterRoomAction;
    }

    private void Start()
    {
        mapDataChanges.OnChangesOnTheMap += miniMapUpdate.UpdateMiniMap;
        mapDataChanges.OnPlayerEnteredRoom += onEnterRoomAction.OnChangeRoomAction;
        playerFactory.OnPlayerCreated += onEnterRoomAction.SetPlayer;
        
        playerFactory.Create();

        mapDataGenerator.GenerateMap(10);
    }

    private void OnDestroy()
    {
        mapDataChanges.OnChangesOnTheMap -= miniMapUpdate.UpdateMiniMap;
        mapDataChanges.OnPlayerEnteredRoom -= onEnterRoomAction.OnChangeRoomAction;
        playerFactory.OnPlayerCreated -= onEnterRoomAction.SetPlayer;
    }
}
