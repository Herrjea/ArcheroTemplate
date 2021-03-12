using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerMovementController movementController;
    Input input;

    Touch touch;


    void Start()
    {
        movementController = GetComponent<PlayerMovementController>();

        input = new Input();
        input.Enable();

        input.Player.Movement.performed += context => DirectMovementInput(context.ReadValue<Vector2>());

        input.Player.Touch.performed += context =>
        {
            //if (context.phase == InputActionPhase.Started)
                Clicked();
        };
    }


    void Update()
    {
        /*if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            movementController.NewInput(touch.position);
        }

        print(Input.touchCount);*/
    }


    void DirectMovementInput(Vector2 direction)
    {
        print("Key movement towards " + direction);
    }

    void Clicked()
    {
        print("Clicked at " + input.Player.MousePosition.ReadValue<Vector2>());
    }
}
