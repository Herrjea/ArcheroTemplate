using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SocketPosition
{
    Front,
    Side,
    Rear
}


public class BulletSocket
{
    public Transform transform;
    public SocketPosition position;

    public BulletSocket(Transform transform, SocketPosition position)
    {
        this.transform = transform;
        this.position = position;
    }
}
