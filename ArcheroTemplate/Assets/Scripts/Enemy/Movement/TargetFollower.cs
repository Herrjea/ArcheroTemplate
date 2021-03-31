using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : EnemyMovement
{
    [SerializeField] protected float seekSpeed = .1f;

    protected Transform player;
    protected Vector3 targetPosition;

    protected float epsilon = 0.01f;
    protected Coroutine movingCoroutine = null;


    protected override void Awake()
    {
        base.Awake();

        player = GameObject.FindWithTag("Player").transform;
    }


    protected IEnumerator MoveToTarget()
    {
        while (
            Mathf.Abs(transform.position.x - targetPosition.x) > epsilon
            &&
            gameObject.activeSelf
        )
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
