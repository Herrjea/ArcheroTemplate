using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResizer : MonoBehaviour
{
    void Awake()
    {
        Camera camera = GetComponent<Camera>();

        float currentFOV = camera.fieldOfView;

        //print("Aspect: " + camera.aspect);
    }
}
