using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : AbstractMovement
{
    protected override void TouchStart(Vector2 position)
    {
        print("TouchMovement touch start");
    }

    protected override void ProcessMovement()
    {
        print("TouchMovement movement loop");
    }

    protected override void TouchEnd()
    {
        print("TouchMovement touch end");
    }
}
