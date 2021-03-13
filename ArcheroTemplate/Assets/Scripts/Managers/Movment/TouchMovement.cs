using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : AbstractMovement
{
    protected override void TouchStart(Vector2 position)
    {
        print("TouchMovement touch start");

        // hacer que el pj deje de atacar ________
    }

    protected override void CalculateVelocity()
    {
        print("TouchMovement movement loop");

        // calcular la worldPosition a la que corresponde la touchPosition ________
        // calcular la velocity ________
    }

    protected override void TouchEnd()
    {
        print("TouchMovement touch end");

        // hacer que el pj vuelva a atacar ________
    }
}
