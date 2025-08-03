using System;
using System.Threading.Tasks;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public async Task MoveToPositionAsync(Vector3 targetPosition, float speed)
    {
        Transform camTransform = mainCamera.transform;

        float fixedZ = camTransform.position.z;
    
        Vector3 target = new Vector3(targetPosition.x, targetPosition.y, fixedZ);

        while (Vector3.Distance(camTransform.position, target) > 0.01f)
        {
            float step = speed * Time.deltaTime;
            camTransform.position = Vector3.MoveTowards(camTransform.position, target, step);
            await Task.Yield();
        }

        camTransform.position = target;
    }
}
