using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidPlayerForward : TargetFollower
{
    [Tooltip(
        "Least horizontal distance from the player that the enemy will try to keep")]
    [SerializeField] float minOffset = 4;
    float targetOffset;
    float currentOffsetSign;

    [Tooltip(
        "Seconds until the enemy attempts a new horizontal avoidance")]
    [SerializeField] float avoidanceCD = 3;


    protected override void Awake()
    {
        base.Awake();

        StartCoroutine(AvoidanceTrigger());

        // Add a slight randomization,
        // in order to make several of the same type together
        // look not so much like a robot swarm
        minOffset = Random.Range(minOffset * (1 - errorMargin), minOffset * (1 + errorMargin));
        avoidanceCD = Random.Range(avoidanceCD * (1 - errorMargin), avoidanceCD * (1 + errorMargin));
    }


    IEnumerator AvoidanceTrigger()
    {
        float currentOffset;
        float targetPositionX;

        while (gameObject.activeSelf && isMoving)
        {
            currentOffset = player.position.x - transform.position.x;

            if (Mathf.Abs(currentOffset) < minOffset)
            {
                currentOffsetSign = Mathf.Sign(currentOffset);
                targetOffset = Random.Range(minOffset, minOffset * 2);

                // Movement horizontally away from the player
                targetPositionX = ComputeTargetXPosition();

                // Movement towards the opposite direction
                // if it would end up outside the screen
                if (Mathf.Abs(targetPositionX) > roomSize.x)
                    targetPositionX = ComputeTargetXPosition(-1);

                targetPosition = new Vector3(
                    targetPositionX,
                    transform.position.y,
                    transform.position.z
                );

                if (movingCoroutine != null)
                    StopCoroutine(movingCoroutine);
                movingCoroutine = StartCoroutine(MoveToTarget());

                yield return new WaitForSeconds(avoidanceCD);
            }
            else
                yield return null;
        }
    }

    float ComputeTargetXPosition(float oppositeDirection = 1)
    {
        return
            player.position.x
            +
            targetOffset * currentOffsetSign * oppositeDirection;
    }
}
