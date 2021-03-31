using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovement : MonoBehaviour
{
    protected float maxSpeed;
    float rollStrength;
    float rotationSeekspeed;
    bool rotateTowardsMoveDirection;

    protected Vector2 touchPosition = new Vector2(-1, -1);

    protected bool isTouching = false;

    Rigidbody rb;
    protected Vector3 velocity = Vector3.zero;


    public void InitParams(float maxSpeed, float rollStrength, float rotationSeekspeed, bool rotateTowardsMoveDirection)
    {
        this.maxSpeed = maxSpeed;
        this.rollStrength = rollStrength;
        this.rotationSeekspeed = rotationSeekspeed;
        this.rotateTowardsMoveDirection = rotateTowardsMoveDirection;
    }

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();

        GameEvents.PlayerDied.AddListener(StopMoving);
    }


    public void TouchPress(Vector2 position)
    {
        touchPosition = position;
        isTouching = true;

        StartCoroutine(UpdateMovement(position));
    }

    public void TouchRelease()
    {
        isTouching = false;
    }

    public void TouchDelta(Vector2 delta)
    {
        touchPosition += delta;
    }

    public void StopMoving()
    {
        TouchRelease();
        rb.velocity = Vector3.zero;
    }


    public IEnumerator UpdateMovement(Vector2 startPosition)
    {
        TouchStart(startPosition);

        while (isTouching)
        {
            CalculateVelocity();

            rb.velocity = velocity;

            RotatePlayer();

            yield return null;
        }

        TouchEnd();

        if (!rotateTowardsMoveDirection)
            DampenRoll();
    }


    void RotatePlayer()
    {
        if (rotateTowardsMoveDirection)
            RotateTowardsMovementDirection();
        else
            HorizontalVelocityRoll();
    }

    void RotateTowardsMovementDirection()
    {
        rb.MoveRotation(
            Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(velocity),
                rotationSeekspeed
            )
        );
    }

    void HorizontalVelocityRoll()
    {
        float roll = -velocity.x * rollStrength;

        rb.MoveRotation(
            Quaternion.Lerp(
                transform.rotation,
                Quaternion.AngleAxis(roll, transform.forward),
                rotationSeekspeed
            )
        );
    }

    // Gradually removes teh applied roll, after the user stops moving the player
    void DampenRoll()
    {
        StartCoroutine(DampenRollCoroutine());
    }

    IEnumerator DampenRollCoroutine()
    {
        while (!isTouching && Mathf.Abs(transform.rotation.z) > .001f)
        {
            transform.rotation = Quaternion.Lerp(
                    transform.rotation,
                    Quaternion.Euler(0, 0, 0),
                    rotationSeekspeed / 2
            );

            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    protected void ClampVelocityToMaxSpeed()
    {
        if (velocity.magnitude > maxSpeed)
            velocity = velocity.normalized * maxSpeed;
    }


    protected abstract void TouchStart(Vector2 position);

    protected abstract void CalculateVelocity();

    protected abstract void TouchEnd();
}
