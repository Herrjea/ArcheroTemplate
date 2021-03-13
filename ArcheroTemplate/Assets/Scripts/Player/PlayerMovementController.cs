using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] bool usingJoystickMovement = false;

    [SerializeField] AbstractMovement[] movementTypes;
    int selectedMovementType;

    [SerializeField] AnimationCurve movementEase = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField] float maxSpeed = 10;


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


        GameEvents.TouchPress.AddListener(TouchPress);

        GameEvents.TouchRelease.AddListener(TouchRelease);

        GameEvents.TouchDelta.AddListener(TouchDelta);

        GameEvents.ChangeMovementType.AddListener(ChangeMovementType);
    }

    void InitMovementTypes()
    {
        if (movementTypes.Length == 0)
            Debug.LogError("No movement type assigned");

        for (int i = 0; i < movementTypes.Length; i++)
        {
            movementTypes[i].InitParams(movementEase, maxSpeed);
            movementTypes[i].enabled = i == selectedMovementType;
        }
    }

    #endregion


    #region Input handling

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