using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    protected Vector2 roomSize = new Vector2(10, 15);

    protected virtual void Awake()
    {
        roomSize = FloorResizer.RoomSize / 2;
    }
}
