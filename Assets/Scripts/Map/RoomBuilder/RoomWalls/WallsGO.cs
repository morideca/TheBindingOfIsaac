using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomsGO", menuName = "Room/RoomsGO")]
public class WallsGO : ScriptableObject
{
    public GameObject smallRoomPrefab;
    public GameObject mediumRoomPrefab;
    public GameObject largeRoomPrefab;
}
