using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] bool usingJoystickMovement = false;

    [SerializeField] float maxSpeed = 10;
    [SerializeField] float rollStrength = 1.5f;
    [SerializeField] float rotationSeekspeed = .9f;
    [SerializeField] bool rotateTowardsMoveDirection = true;

    [SerializeField] AbstractMovement[] movementTypes;
    int selectedMovementType;


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

    void TouchDelta(Vector2 delta)
    {
        Movement.TouchDelta(delta);
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
}