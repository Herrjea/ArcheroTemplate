using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    static float magicNumber = 38;
    static float fixedHeight = 26;
    static float margin = 3;

    static Vector2 size = Vector2.zero;


    public static Vector2 RoomSize
    {
        get
        {
            if (size.Equals(Vector2.zero))
                size = new Vector2(
                    Screen.width / magicNumber + margin,
                    fixedHeight
                );

            return size;
        }
    }
}
