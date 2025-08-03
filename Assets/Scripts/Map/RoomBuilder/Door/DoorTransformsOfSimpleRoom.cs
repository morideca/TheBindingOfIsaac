using UnityEngine;

public class DoorTransformsOfSimpleRoom: MonoBehaviour
{
    [SerializeField] private GameObject leftDoorTransform;
    [SerializeField] private GameObject rightDoorTransform;
    [SerializeField] private GameObject topDoorTransform;
    [SerializeField] private GameObject bottomDoorTransform;

    public GameObject LeftDoorTransform => leftDoorTransform;
    public GameObject RightDoorTransform => rightDoorTransform;
    public GameObject TopDoorTransform => topDoorTransform;
    public GameObject BottomDoorTransform => bottomDoorTransform;
    
    
}
