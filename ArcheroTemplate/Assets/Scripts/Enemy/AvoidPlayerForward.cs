using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidPlayerForward : EnemyMovement
{
    [Tooltip(
        "Least horizontal distance from the player that the enemy will try to keep")]
    [SerializeField] float minOffset = 4;
    float targetOffset;
    float currentOffsetSign;

    [Tooltip(
        "Seconds until the enemy attempts a new horizontal avoidance")]
    [SerializeField] float avoidanceCD = 3;

    Vector3 targetPosition;

    float epsilon = 0.01f;
    Coroutine avoidCoroutine = null;


    void Start()
    {
        StartCoroutine(AvoidanceTrigger());
    }


    IEnumerator AvoidanceTrigger()
    {
        float currentOffset;

        while (gameObject.activeSelf)
        {
            currentOffset = player.position.x - transform.position.x;

            if (Mathf.Abs(currentOffset) < minOffset)
            {
                currentOffsetSign = Mathf.Sign(currentOffset);
                targetOffset = Random.Range(minOffset, minOffset * 2);

                // Movement horizontally away from the player
                targetPosition = ComputeTargetPosition();

                // Movement towards the opposite direction
                // if it would end up outside the screen
                if (Mathf.Abs(targetPosition.x) > roomSize.x)
                    targetPosition = ComputeTargetPosition(-1);

                if (avoidCoroutine != null)
                    StopCoroutine(avoidCoroutine);
                avoidCoroutine = StartCoroutine(Avoid());

                yield return new WaitForSeconds(avoidanceCD);
            }
            else
                yield return null;
        }
    }

    Vector3 ComputeTargetPosition(float oppositeDirection = 1)
    {
        return new Vector3(
            player.position.x + targetOffset * currentOffsetSign * oppositeDirection,
            transform.position.y,
            transform.position.z
        );
    }


    IEnumerator Avoid()
    {
        while (Mathf.Abs(transform.position.x - targetPosition.x) > epsilon)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                seekSpeed
            );

            yield return null;
        }
    }
}
