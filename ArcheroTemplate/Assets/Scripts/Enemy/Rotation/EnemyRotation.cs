using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField] protected float rotationSeekspeed = 0.1f;
    protected Vector3 lookRotation = Vector3.zero;


    protected void FixedUpdate()
    {
        ComputeLookRotation();

        Rotate();
    }


    protected virtual void ComputeLookRotation()
    {
        Debug.LogError("Unimplemented EnemyRotation::ComputeLookRotation member");
    }

    protected virtual void Rotate()
    {
        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(lookRotation),
                rotationSeekspeed
            );
    }
}
