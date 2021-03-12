using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerMovementController movementController;

    Touch touch;


    void Start()
    {
        movementController = GetComponent<PlayerMovementController>();
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            movementController.NewInput(touch.position);
        }

        print(Input.touchCount);
    }
}
