using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceVelocity : EnemyRotation
{
    Vector3 previousPosition;
    Vector3 currentLookRotation;
    float epsilon = 0.1f;


    void Awake()
    {
        previousPosition = transform.position;
    }


    protected override void ComputeLookRotation()
    {
            currentLookRotation = transform.position - previousPosition;

            if (currentLookRotation.magnitude > epsilon)
            {
                lookRotation = currentLookRotation;

                previousPosition = transform.position;
            }
    }
}
