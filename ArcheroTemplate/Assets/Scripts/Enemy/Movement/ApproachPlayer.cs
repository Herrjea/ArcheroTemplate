using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachPlayer : EnemyMovement
{
    [SerializeField] float speed = 2f;

    Transform player;


    protected override void Awake()
    {
        base.Awake();

        player = GameObject.FindWithTag("Player").transform;

        // Add a slight randomization,
        // in order to make several of the same type together
        // look not so much like a robot swarm
        speed = Random.Range(speed * (1 - errorMargin), speed * (1 + errorMargin));
    }


    protected void LateUpdate()
    {
        if (isMoving)
            transform.position +=
                (player.position - transform.position).normalized
                *
                speed
                *
                Time.deltaTime;
    }
}
