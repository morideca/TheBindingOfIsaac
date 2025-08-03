using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    public GameObject PlayerPrefab;
    public GameObject InputHandler;
    public GameObject BootstrapPrefab;
    public GameObject RoomBuilderPrefab;
    public GameObject MiniMapPrefab;
    public GameObject CameraMovePrefab;
    
    public override void InstallBindings()
    {
        BindBootstrap();
        
        BindInputService();
        
        BindPlayerRegister();
        BindPlayerFactory(); 
        BindPlayerCharacteristics();
        
        BindMapData();
        BindMiniMap();

        BindRoomDestroyer();
        BindRoomObjects();
        BindRoomBuilder();

        BindPlayerTeleport();
        BindDoorsManager();
        BindTransitionBetweenRooms();

        BindCameraMove();
    }

    private void BindRoomDestroyer()
    {
        Container
            .Bind<IRoomDestroyer>()
            .To<RoomDestroyer>()
            .AsSingle();
    }

    private void BindRoomObjects()
    {
        Container
            .Bind<RoomObjects>()
            .AsSingle();
    }

    private void BindDoorsManager()
    {
        Container
            .Bind<DoorsManager>()
            .AsSingle();
    }

    private void BindPlayerTeleport()
    {
        Container
            .Bind<ITeleportPlayer>()
            .To<PlayerTeleport>()
            .AsSingle();
    }

    private void BindCameraMove()
    {
        var cameraMove = Container.InstantiatePrefabForComponent<CameraMove>(CameraMovePrefab);
        Container
            .Bind<CameraMove>()
            .FromInstance(cameraMove)
            .AsSingle();
    }

    private void BindMiniMap()
    {
        var miniMap = Container.InstantiatePrefabForComponent<MiniMapView>(MiniMapPrefab);
        Container
            .Bind<IMiniMapUpdate>()
            .FromInstance(miniMap)
            .AsSingle();
    }

    private void BindPlayerRegister()
    {
        Container
            .Bind<PlayerRegister>()
            .AsSingle();
    }

    private void BindRoomBuilder()
    {
        var roomBuilder = Container.InstantiatePrefabForComponent<RoomBuilder>(RoomBuilderPrefab);
        Container
            .BindInterfacesTo<RoomBuilder>()
            .FromInstance(roomBuilder)
            .AsSingle();
    }

    private void BindBootstrap()
    {
        Container
            .Bind<BootStrap>()
            .FromComponentInNewPrefab(BootstrapPrefab)
            .AsSingle()
            .NonLazy();
    }


    private void BindInputService()
    {
        InputHandler inputHandler = Container.InstantiatePrefabForComponent<InputHandler>(InputHandler);

        Container
            .Bind<IInputService>()
            .FromInstance(inputHandler)
            .AsSingle();
    }

    private void BindPlayerFactory()
    {
        Container
            .Bind<IPlayerFactory>()
            .To<PlayerFactory>()
            .AsSingle()
            .WithArguments(PlayerPrefab);

    }

    private void BindTransitionBetweenRooms()
    {
        Container
            .Bind<IOnEnterRoomAction>()
            .To<TransitionBetweenRooms>()
            .AsSingle();
    }

    private void BindMapData()
    {
        Container
            .BindInterfacesTo<Map>()
            .AsSingle();
    }

    private void BindRoomFilling()
    {
        Container
            .Bind<CurrentRoomFilling>()
            .AsSingle();
    }

    private void BindPlayerCharacteristics()
    {
        Container
            .Bind<PlayerCharacteristics>()
            .AsSingle();
    }
}
