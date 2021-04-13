using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SocketPosition
{
    Front,
    Left,
    Right,
    Rear,
    BothSides
}


public class ProjSocket
{
    public Transform transform;
    public SocketPosition position;
    public ParticleSystem muzzleFlash;

    public ProjSocket(Transform transform, SocketPosition position, ParticleSystem muzzleFlash)
    {
        this.transform = transform;
        this.position = position;
        this.muzzleFlash = muzzleFlash;
    }


    public void NewShot()
    {
        if (muzzleFlash != null)
            muzzleFlash.Play();
    }
}
