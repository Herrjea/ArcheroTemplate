using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleInPlace : EnemyMovement
{
    [SerializeField] Vector2 frequency;
    [SerializeField] Vector2 amplitude;


    void LateUpdate()
    {
        if (isMoving)
            transform.position +=
                (
                    Vector3.right * Mathf.Sin(Time.time * frequency.x) * amplitude.x
                    +
                    Vector3.forward * Mathf.Cos(Time.time * frequency.y) * amplitude.y
                )
                *
                Time.deltaTime;
    }
}
