using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SocketPosition
{
    Front,
    Side,
    Rear
}


public class ProjSocket
{
    public Transform transform;
    public SocketPosition position;

    public ProjSocket(Transform transform, SocketPosition position)
    {
        this.transform = transform;
        this.position = position;
    }
}
