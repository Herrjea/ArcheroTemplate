using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : NPCMovement
{
    protected Vector2 roomSize = new Vector2(10, 15);

    protected override void Awake()
    {
        base.Awake();

        roomSize = Room.RoomSize / 2;
    }
}
