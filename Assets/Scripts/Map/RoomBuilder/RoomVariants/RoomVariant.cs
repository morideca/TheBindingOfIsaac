using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Obstacles", menuName = "Room/ObstaclesGO")]
public class GameObjectConstructions : ScriptableObject
{
    public List<GameObject> ObstaclesGO;
}
