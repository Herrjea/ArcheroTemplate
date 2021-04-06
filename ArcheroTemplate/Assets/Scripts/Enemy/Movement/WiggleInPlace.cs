using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleInPlace : EnemyMovement
{
    [SerializeField] Vector2 frequency;
    [SerializeField] Vector2 amplitude;


    protected override void Awake()
    {
        // Add a slight randomization,
        // in order to make several of the same type together
        // look not so much like a robot swarm
        frequency = new Vector2(
            Random.Range(frequency.x * (1 - errorMargin), frequency.x * (1 + errorMargin)),
            Random.Range(frequency.y * (1 - errorMargin), frequency.y * (1 + errorMargin))
        );
        amplitude = new Vector2(
            Random.Range(amplitude.x * (1 - errorMargin), amplitude.x * (1 + errorMargin)),
            Random.Range(amplitude.y * (1 - errorMargin), amplitude.y * (1 + errorMargin))
        );
    }

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
