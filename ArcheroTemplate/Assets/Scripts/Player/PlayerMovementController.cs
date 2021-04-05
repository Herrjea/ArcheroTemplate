﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class PlayerMovementController : MonoBehaviour, IPushable
{
    [SerializeField] bool usingJoystickMovement = false;

    [SerializeField] float maxSpeed = 10;
    [SerializeField] float rollStrength = 1.5f;
    [SerializeField] float rotationSeekspeed = .9f;
    [SerializeField] bool rotateTowardsMoveDirection = true;

    [SerializeField] AbstractMovement[] movementTypes;
    int selectedMovementType;

    Rigidbody rb;


    AbstractMovement Movement
    {
        get => movementTypes[selectedMovementType];
    }

    public int CurrentMovementType
    {
        set
        {
            if (value >= movementTypes.Length)
            {
                Debug.LogError("Unknown movement type: " + value);
            }
            else if (value != selectedMovementType)
            {
                Movement.enabled = false;
                selectedMovementType = value;
                Movement.enabled = true;
            }
        }
    }


    #region Init

    private void Start()
    {
        selectedMovementType = 0;

        InitMovementTypes();

        StartMoving();

        GameEvents.ChangeMovementType.AddListener(ChangeMovementType);

        GameEvents.PlayerDied.AddListener(StopMoving);

        rb = GetComponent<Rigidbody>();


    }

    void InitMovementTypes()
    {
        if (movementTypes.Length == 0)
            Debug.LogError("No movement type assigned");

        for (int i = 0; i < movementTypes.Length; i++)
        {
            movementTypes[i].InitParams(maxSpeed, rollStrength, rotationSeekspeed, rotateTowardsMoveDirection);
            movementTypes[i].enabled = i == selectedMovementType;
        }
    }

    #endregion


    #region Input handling

    void StartMoving()
    {
        GameEvents.TouchPress.AddListener(TouchPress);

        GameEvents.TouchRelease.AddListener(TouchRelease);

        GameEvents.TouchDelta.AddListener(TouchDelta);
    }

    void StopMoving()
    {
        GameEvents.TouchPress.RemoveListener(TouchPress);

        GameEvents.TouchRelease.RemoveListener(TouchRelease);

        GameEvents.TouchDelta.RemoveListener(TouchDelta);
    }

    void TouchPress(Vector2 position)
    {
        Movement.TouchPress(position);
    }

    void TouchRelease()
    {
        Movement.TouchRelease();
    }

    void TouchDelta(Vector2 delta, Vector2 newPosition)
    {
        Movement.TouchDelta(delta, newPosition);
    }

    void ChangeMovementType()
    {
        if (selectedMovementType == movementTypes.Length - 1)
            CurrentMovementType = 0;
        else
            CurrentMovementType = selectedMovementType + 1;

        print("Movement type chaned to " + selectedMovementType);
    }

    #endregion


    public void ReceivePushForce(float strength, Vector3 from, float radius)
    {
        rb.AddExplosionForce(strength, from, radius);
    }
}