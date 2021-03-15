using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : AbstractMovement
{
    [SerializeField] float ignoreDistance = .5f;
    [SerializeField] float speedSmothingDistance = 5;
    [SerializeField] AnimationCurve speedSmothEase = AnimationCurve.EaseInOut(0, 0, 1, 1);

    new Camera camera;

    int floorMask;
    float rayLength = 100;
    float velocityMagnitude;


    protected override void Awake()
    {
        base.Awake();

        camera = Camera.main;
        floorMask = LayerMask.GetMask("Floor");
    }


    protected override void TouchStart(Vector2 position)
    {
        // hacer que el pj deje de atacar ________
    }

    protected override void CalculateVelocity()
    {
        // Get the worldPposition corresponding to the current touchPosition
        Ray cameraRay = camera.ScreenPointToRay(touchPosition);
        RaycastHit floorHit;
        if (Physics.Raycast(cameraRay, out floorHit, rayLength, floorMask))
        {
            velocity = floorHit.point - transform.position;
            velocityMagnitude = velocity.magnitude;

            // Stop moving if close enough to touch position
            if (velocityMagnitude < ignoreDistance)
                velocity = Vector3.zero;
            // Smooth break near touch position
            else if (velocityMagnitude < speedSmothingDistance)
                SmoothVelocity();
            // Instant acceleration otherwise
            else
                MaximizeVelocity();
        }
        else
        {
            print("There really was no floor covering some pixels??");
        }
    }

    protected override void TouchEnd()
    {
        // hacer que el pj vuelva a atacar ________
    }


    void SmoothVelocity()
    {
        velocity = velocity.normalized * speedSmothEase.Evaluate(velocityMagnitude / speedSmothingDistance) * maxSpeed;
    }

    void MaximizeVelocity()
    {
        velocity = velocity.normalized * maxSpeed;
    }
}
