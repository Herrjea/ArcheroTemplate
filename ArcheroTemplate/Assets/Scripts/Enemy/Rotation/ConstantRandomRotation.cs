using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRandomRotation : EnemyRotation
{
    [SerializeField] float minAngularSpeed = -1;
    [SerializeField] float maxAngularSpeed = 1;
    Vector3 angularSpeeds;


    void Awake()
    {
        angularSpeeds = new Vector3(
            Random.Range(minAngularSpeed, maxAngularSpeed),
            Random.Range(minAngularSpeed, maxAngularSpeed),
            Random.Range(minAngularSpeed, maxAngularSpeed)
        );
    }


    protected override void ComputeLookRotation()
    {
        
    }

    protected override void Rotate()
    {
        transform.Rotate(angularSpeeds);
    }
}
