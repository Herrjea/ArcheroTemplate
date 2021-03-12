using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] bool usingJoystickMovement = false;

    AbstractMovement[] movement = new AbstractMovement[2];
    int joystickMovement = 0;
    int touchMovement = 1;
    int selectedMovType = 0;


    private void Start()
    {
        movement[joystickMovement] = new JoystickMovement();
        movement[touchMovement] = new TouchMovement();
    }


    public void NewInput(Vector3 position)
    {
        print(position);
    }
}
