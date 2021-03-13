using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovement : MonoBehaviour
{
    protected Vector2 touchPosition = new Vector2(-1, -1);

    protected bool isTouching = false;


    public void TouchPress(Vector2 position)
    {
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
            ProcessMovement();

            yield return null;
        }

        TouchEnd();
    }


    protected abstract void TouchStart(Vector2 position);

    protected abstract void ProcessMovement();

    protected abstract void TouchEnd();
}
