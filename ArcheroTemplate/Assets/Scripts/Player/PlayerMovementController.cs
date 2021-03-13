using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] bool usingJoystickMovement = false;

    [SerializeField] AbstractMovement[] movement;
    int selectedMovementType;


    AbstractMovement Movement
    {
        get => movement[selectedMovementType];
    }

    public int CurrentMovementType
    {
        set
        {
            if (value >= movement.Length)
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
    }

    void InitMovementTypes()
    {
        for (int i = 0; i < movement.Length; i++)
            if (i != selectedMovementType)
                movement[i].enabled = false;
    }

    #endregion


    #region Input handling

    void TouchPress(Vector2 position)
    {
        //print("Touch started at " + position);

        Movement.TouchPress(position);
    }

    void TouchRelease()
    {
        //print("Touch released");

        Movement.TouchRelease();
    }

    void TouchDelta(Vector2 delta)
    {
        //print("delta of " + delta);

        Movement.TouchDelta(delta);
    }

    #endregion
}