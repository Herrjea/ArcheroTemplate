using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour, IPushable
{
    protected bool isMoving = true;
    protected Rigidbody rb;


    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void StartMoving()
    {
        isMoving = true;
    }

    public virtual void StopMoving()
    {
        isMoving = false;
    }


    public void ReceivePushForce(float strength, Vector3 from, float radius)
    {
        rb?.AddExplosionForce(strength, from, radius);
    }
}
