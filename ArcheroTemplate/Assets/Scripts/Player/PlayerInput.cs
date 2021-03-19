﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerMovementController movementController;
    PlayerShot shotController;
    Input input;

    Touch touch;


    #region Initialization

    void Awake()
    {
        movementController = GetComponent<PlayerMovementController>();
        shotController = GetComponent<PlayerShot>();
        shotController.StartShooting();

        input = new Input();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Start()
    {
        //
        // Mouse
        //

        input.Player.Movement.performed += context => DirectMovementInput(context.ReadValue<Vector2>());

        input.Player.MouseLeft.performed += context => Clicked();

        //
        // Touch screen
        //

        input.Player.TouchPress.started += context => TouchPress();

        input.Player.TouchPress.canceled += context => TouchReleased();

        input.Player.TouchDelta.performed += context => TouchDelta(context.ReadValue<Vector2>());

        input.Player.ChanegMovementType.performed += context => ChangeMovementType();
    }

    #endregion


    #region Mouse

    void DirectMovementInput(Vector2 direction)
    {
        print("Key movement towards " + direction);
    }

    void Clicked()
    {
        //print("Clicked at " + input.Player.MousePosition.ReadValue<Vector2>());
    }

    #endregion


    #region Touch screen

    void TouchPress()
    {
        //Debug.Log("Touch press at " + input.Player.TouchPosition.ReadValue<Vector2>());

        GameEvents.TouchPress.Invoke(input.Player.TouchPosition.ReadValue<Vector2>());
    }

    void TouchReleased()
    {
        //Debug.Log("Touch released from " + input.Player.TouchPosition.ReadValue<Vector2>());

        GameEvents.TouchRelease.Invoke();
    }

    void TouchDelta(Vector2 delta)
    {
        //print("delta: " + delta);

        GameEvents.TouchDelta.Invoke(delta);
    }

    #endregion


    #region Debug

    void ChangeMovementType()
    {
        GameEvents.ChangeMovementType.Invoke();
    }

    #endregion
}
