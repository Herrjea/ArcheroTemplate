// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Managers/Input/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d953ab6d-6501-460a-aa59-bcf94d0670d8"",
            ""actions"": [
                {
                    ""name"": ""MouseLeft"",
                    ""type"": ""Button"",
                    ""id"": ""8445a918-0bec-4300-a65d-836e66f36974"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ba1234bb-382a-48da-a678-3ccf43a0da6c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e6bc08f1-bd7b-40cb-aab5-f30ae592a006"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""Value"",
                    ""id"": ""e91d8c3b-a9be-4fd3-8830-c88ac1cb546d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchDelta"",
                    ""type"": ""Value"",
                    ""id"": ""a4c14636-6305-43ed-91f3-a011566d0531"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""abd521ff-5ca6-49fe-a247-5a3c355193fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchHold"",
                    ""type"": ""Button"",
                    ""id"": ""7e91029b-732c-4f05-8833-05961a956421"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""TouchRelease"",
                    ""type"": ""Button"",
                    ""id"": ""04130741-f273-462e-8027-bcfdcad53abd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4060f7bf-fd88-4435-8202-4ab54cfbe565"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b8bb5c9-af89-4d66-8eaf-9c7550f115e6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""490cb0f6-5f45-4355-846b-50a7bcbfdfd5"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""4f498ab2-5fbd-4e77-8876-efdea270734d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ca95b994-5fb3-44f1-adc9-16faf493ae90"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""76f0e6d5-60c3-47f3-b188-3b1a788387e9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8b272423-78ef-4fbc-9231-ae6824e1e43f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1dd99726-240d-410c-bc92-053730a06c92"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""6dd1e3d1-3780-4308-b3ff-bcb637a24022"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f0aa80ce-4073-4fb9-9fdb-6cb8578213c8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""01db75f8-a5a4-4317-b8e1-30ed468a6573"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""34af7f73-b9a6-4ac5-8f81-ff190268fa83"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b25a6455-bd43-47e7-8980-e800ef84d645"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b3781af1-36be-452f-beff-ffb321685061"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4703668-6900-4e33-b26c-05207c1d6916"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d76805c-f35e-4e1d-96bb-a42e72ed6e2b"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56f10c63-4b9c-4dc6-af1b-b070f4eb42f7"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MouseLeft = m_Player.FindAction("MouseLeft", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_MousePosition = m_Player.FindAction("MousePosition", throwIfNotFound: true);
        m_Player_TouchPosition = m_Player.FindAction("TouchPosition", throwIfNotFound: true);
        m_Player_TouchDelta = m_Player.FindAction("TouchDelta", throwIfNotFound: true);
        m_Player_TouchPress = m_Player.FindAction("TouchPress", throwIfNotFound: true);
        m_Player_TouchHold = m_Player.FindAction("TouchHold", throwIfNotFound: true);
        m_Player_TouchRelease = m_Player.FindAction("TouchRelease", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MouseLeft;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_MousePosition;
    private readonly InputAction m_Player_TouchPosition;
    private readonly InputAction m_Player_TouchDelta;
    private readonly InputAction m_Player_TouchPress;
    private readonly InputAction m_Player_TouchHold;
    private readonly InputAction m_Player_TouchRelease;
    public struct PlayerActions
    {
        private @Input m_Wrapper;
        public PlayerActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseLeft => m_Wrapper.m_Player_MouseLeft;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @MousePosition => m_Wrapper.m_Player_MousePosition;
        public InputAction @TouchPosition => m_Wrapper.m_Player_TouchPosition;
        public InputAction @TouchDelta => m_Wrapper.m_Player_TouchDelta;
        public InputAction @TouchPress => m_Wrapper.m_Player_TouchPress;
        public InputAction @TouchHold => m_Wrapper.m_Player_TouchHold;
        public InputAction @TouchRelease => m_Wrapper.m_Player_TouchRelease;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MouseLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseLeft;
                @MouseLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseLeft;
                @MouseLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseLeft;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @MousePosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @TouchPosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPosition;
                @TouchDelta.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchDelta;
                @TouchDelta.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchDelta;
                @TouchDelta.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchDelta;
                @TouchPress.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPress;
                @TouchHold.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchHold;
                @TouchHold.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchHold;
                @TouchHold.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchHold;
                @TouchRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchRelease;
                @TouchRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchRelease;
                @TouchRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchRelease;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseLeft.started += instance.OnMouseLeft;
                @MouseLeft.performed += instance.OnMouseLeft;
                @MouseLeft.canceled += instance.OnMouseLeft;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
                @TouchDelta.started += instance.OnTouchDelta;
                @TouchDelta.performed += instance.OnTouchDelta;
                @TouchDelta.canceled += instance.OnTouchDelta;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchHold.started += instance.OnTouchHold;
                @TouchHold.performed += instance.OnTouchHold;
                @TouchHold.canceled += instance.OnTouchHold;
                @TouchRelease.started += instance.OnTouchRelease;
                @TouchRelease.performed += instance.OnTouchRelease;
                @TouchRelease.canceled += instance.OnTouchRelease;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMouseLeft(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnTouchDelta(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchHold(InputAction.CallbackContext context);
        void OnTouchRelease(InputAction.CallbackContext context);
    }
}
