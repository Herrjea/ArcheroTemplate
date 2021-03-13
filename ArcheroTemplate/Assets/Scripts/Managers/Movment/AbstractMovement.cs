using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovement : MonoBehaviour
{
    protected AnimationCurve movementEase;
    protected float maxSpeed;

    protected Vector2 touchPosition = new Vector2(-1, -1);

    protected bool isTouching = false;

    Rigidbody rb;
    protected Vector3 velocity = Vector3.zero;


    public void InitParams(AnimationCurve movementEase, float maxSpeed)
    {
        this.movementEase = movementEase;
        this.maxSpeed = maxSpeed;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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


    public IEnumerator UpdateMovement(Vector2 startPosition)
    {
        TouchStart(startPosition);

        while (isTouching)
        {
            CalculateVelocity();

            rb.velocity = velocity;

            // rotar al pj hacia su velocity

            yield return null;
        }

        // permitir una frenada gradual al dejar de tocar la pantalla? _________

        TouchEnd();
    }


    protected abstract void TouchStart(Vector2 position);

    protected abstract void CalculateVelocity();

    protected abstract void TouchEnd();
}
