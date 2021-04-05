using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorResizer : MonoBehaviour
{
    void Awake()
    {
        transform.Find("Sprite").localScale = new Vector3(
            Room.RoomSize.x,
            Room.RoomSize.y,
            1
        );

        print($"Screen size: {Screen.width} , {Screen.height}");
    }
}
