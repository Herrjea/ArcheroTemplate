using UnityEngine;

public class FloorResizer : MonoBehaviour
{
    void Awake()
    {
        transform.Find("Sprite").localScale = new Vector3(
            Room.RoomSize.x,
            Room.RoomSize.y,
            transform.localScale.z
        );

        print($"Screen size: {Screen.width} , {Screen.height}");
    }
}
