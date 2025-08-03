using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapView : MonoBehaviour, IMiniMapUpdate
{
    public Image miniMapIconPrefab;
    public Transform miniMapParent;

    public void UpdateMiniMap(Dictionary<Vector2, RoomData> map, Vector2 currentRoomPosition)
    {
        foreach (Transform child in miniMapParent)
            Destroy(child.gameObject);

        foreach (var room in map.Values)
        { 
             if (!room.isDiscovered) continue;

             Image icon = Instantiate(miniMapIconPrefab, miniMapParent);
             RectTransform rt = icon.GetComponent<RectTransform>();

             Vector2 relativePos = room.Position - currentRoomPosition;
             rt.anchoredPosition = new Vector2(relativePos.x * 18, relativePos.y * 18); 

             rt.sizeDelta = new Vector2(15, 15);
             rt.localScale = Vector3.one;
             rt.anchorMin = rt.anchorMax = new Vector2(0.5f, 0.5f);
             rt.pivot = new Vector2(0.5f, 0.5f);
             
             if (room.Type == RoomType.Start) icon.color = Color.green;
             else if (room.Type == RoomType.Boss) icon.color = Color.red;
             else if (room.Type == RoomType.Treasure) icon.color = Color.yellow;
             else icon.color = room.isCleared ? Color.white : Color.gray;
        }
    }
}
