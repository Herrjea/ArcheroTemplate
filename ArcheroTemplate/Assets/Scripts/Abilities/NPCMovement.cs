using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    protected bool isMoving = true;


    public void StartMoving()
    {
        isMoving = true;
    }

    public virtual void StopMoving()
    {
        isMoving = false;
    }
}
