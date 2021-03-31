using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    static float magicNumber = 40.7f;
    static Vector2 size = Vector2.zero;


    public static Vector2 RoomSize
    {
        get
        {
            if (size.Equals(Vector2.zero))
                size = new Vector2(
                    Screen.width / magicNumber,
                    Screen.height / magicNumber
                );

            return size;
        }
    }
}
