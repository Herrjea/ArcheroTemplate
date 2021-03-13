using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : AbstractMovement
{
    protected override void TouchStart(Vector2 position)
    {
        print("JoystickMovement touch start");
    }

    protected override void ProcessMovement()
    {
        print("JoystickMovement movement loop");
    }

    protected override void TouchEnd()
    {
        print("JoystickMovement touch end");
    }
}
