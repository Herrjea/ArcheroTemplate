using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : AbstractMovement
{
    new Camera camera;

    int floorMask;
    float rayLength = 100;


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
            ClampVelocityToMaxSpeed();
            print(velocity);
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
}
