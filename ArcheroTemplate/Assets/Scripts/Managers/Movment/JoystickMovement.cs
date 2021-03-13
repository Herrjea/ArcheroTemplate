using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : AbstractMovement
{
    [SerializeField] float maxOffset = 100;

    Vector2 joystickPosition = new Vector2(-1, -1);

    // referencia a la UI del joystick ________


    protected override void TouchStart(Vector2 position)
    {
        print("JoystickMovement touch start");

        // actualizar joystickPosition ________
        // colocar la UI del joystick en la posición del touch ________

        // hacer que el pj deje de atacar ________
    }

    protected override void ProcessMovement()
    {
        print("JoystickMovement movement loop");

        // recalcular vector entre la posición del joystick y la posición del touch  actual ________
        // actualizar la UI del joystick ________
        // mover al pj con la dirección y magnitud del vector de antes ________
    }

    protected override void TouchEnd()
    {
        print("JoystickMovement touch end");

        // ocultar la UI del joystick ________

        // hacer que el pj vuelva a atacar ________
    }
}
