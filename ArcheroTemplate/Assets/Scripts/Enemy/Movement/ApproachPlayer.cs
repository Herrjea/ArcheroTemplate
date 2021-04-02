using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachPlayer : EnemyMovement
{
    [SerializeField] float speed = 2f;
    float velocityMagnitude;

    Transform player;


    protected override void Awake()
    {
        base.Awake();

        player = GameObject.FindWithTag("Player").transform;
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
