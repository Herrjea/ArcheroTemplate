using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : AbstractMovement
{
    [SerializeField] float maxOffset = 100;

    Vector2 joystickPosition = new Vector2(-1, -1);
    Vector2 currentOffset = Vector2.zero;

    // referencia a la UI del joystick ________


    protected override void TouchStart(Vector2 position)
    {
        joystickPosition = position;


        // colocar la UI del joystick en la posición del touch ________

        // hacer que el pj deje de atacar ________
    }

    protected override void CalculateVelocity()
    {
        if (touchPosition != joystickPosition)
        {
            currentOffset = touchPosition - joystickPosition;
            // actualizar la UI del joystick ________

            velocity = new Vector3(currentOffset.x, 0, currentOffset.y);
            ClampVelocityToMaxSpeed();

            print($"touchPosition: {touchPosition} , joystickPosition: {joystickPosition} , offset: {currentOffset}");
        }
    }

    protected override void TouchEnd()
    {
        joystickPosition = new Vector2(-1, -1);
        currentOffset = Vector2.zero;

        // ocultar la UI del joystick ________

        // hacer que el pj vuelva a atacar ________
    }
}
