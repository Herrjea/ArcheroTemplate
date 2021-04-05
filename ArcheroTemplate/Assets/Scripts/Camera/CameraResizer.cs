using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResizer : MonoBehaviour
{
    void Awake()
    {
        Camera camera = GetComponent<Camera>();

        float currentFOV = camera.fieldOfView;

        float targetFieldOfView =
            Mathf.Atan2(
                (Room.RoomSize.y / 2),
                transform.position.y + 1 // vertical distance from the floor to the world's origin
            )
            *
            Mathf.Rad2Deg
            *
            2;

        camera.fieldOfView = targetFieldOfView;
    }
}
