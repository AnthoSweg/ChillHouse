//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/RenderPipeline/Inputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Inputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Placement"",
            ""id"": ""7fc86b87-bd56-4d84-885b-e5c8b770508b"",
            ""actions"": [
                {
                    ""name"": ""MainClick"",
                    ""type"": ""Value"",
                    ""id"": ""b880e569-6f14-4109-b785-ac3f13928129"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SecondClick"",
                    ""type"": ""Button"",
                    ""id"": ""578ebcb6-837d-42b1-93c3-71a730f94051"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PointerDelta"",
                    ""type"": ""Value"",
                    ""id"": ""a7dd5673-d5f8-4186-b001-b755e21fa469"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PointerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""b1817a42-e37a-4eb4-8556-9cfd60bd171b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""77818175-d370-40d5-95ca-c3b545e5750e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold(pressPoint=0.25)"",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""MainClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce98006b-3687-46b6-8dd2-6f58618fc305"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PointerDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fcb724c-0a1a-4309-821e-50cc00eaa5f7"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PointerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ade4ce38-d551-4b37-9359-48e96cf3dcc4"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""SecondClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": []
        }
    ]
}");
        // Placement
        m_Placement = asset.FindActionMap("Placement", throwIfNotFound: true);
        m_Placement_MainClick = m_Placement.FindAction("MainClick", throwIfNotFound: true);
        m_Placement_SecondClick = m_Placement.FindAction("SecondClick", throwIfNotFound: true);
        m_Placement_PointerDelta = m_Placement.FindAction("PointerDelta", throwIfNotFound: true);
        m_Placement_PointerPosition = m_Placement.FindAction("PointerPosition", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Placement
    private readonly InputActionMap m_Placement;
    private IPlacementActions m_PlacementActionsCallbackInterface;
    private readonly InputAction m_Placement_MainClick;
    private readonly InputAction m_Placement_SecondClick;
    private readonly InputAction m_Placement_PointerDelta;
    private readonly InputAction m_Placement_PointerPosition;
    public struct PlacementActions
    {
        private @Inputs m_Wrapper;
        public PlacementActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MainClick => m_Wrapper.m_Placement_MainClick;
        public InputAction @SecondClick => m_Wrapper.m_Placement_SecondClick;
        public InputAction @PointerDelta => m_Wrapper.m_Placement_PointerDelta;
        public InputAction @PointerPosition => m_Wrapper.m_Placement_PointerPosition;
        public InputActionMap Get() { return m_Wrapper.m_Placement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlacementActions set) { return set.Get(); }
        public void SetCallbacks(IPlacementActions instance)
        {
            if (m_Wrapper.m_PlacementActionsCallbackInterface != null)
            {
                @MainClick.started -= m_Wrapper.m_PlacementActionsCallbackInterface.OnMainClick;
                @MainClick.performed -= m_Wrapper.m_PlacementActionsCallbackInterface.OnMainClick;
                @MainClick.canceled -= m_Wrapper.m_PlacementActionsCallbackInterface.OnMainClick;
                @SecondClick.started -= m_Wrapper.m_PlacementActionsCallbackInterface.OnSecondClick;
                @SecondClick.performed -= m_Wrapper.m_PlacementActionsCallbackInterface.OnSecondClick;
                @SecondClick.canceled -= m_Wrapper.m_PlacementActionsCallbackInterface.OnSecondClick;
                @PointerDelta.started -= m_Wrapper.m_PlacementActionsCallbackInterface.OnPointerDelta;
                @PointerDelta.performed -= m_Wrapper.m_PlacementActionsCallbackInterface.OnPointerDelta;
                @PointerDelta.canceled -= m_Wrapper.m_PlacementActionsCallbackInterface.OnPointerDelta;
                @PointerPosition.started -= m_Wrapper.m_PlacementActionsCallbackInterface.OnPointerPosition;
                @PointerPosition.performed -= m_Wrapper.m_PlacementActionsCallbackInterface.OnPointerPosition;
                @PointerPosition.canceled -= m_Wrapper.m_PlacementActionsCallbackInterface.OnPointerPosition;
            }
            m_Wrapper.m_PlacementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MainClick.started += instance.OnMainClick;
                @MainClick.performed += instance.OnMainClick;
                @MainClick.canceled += instance.OnMainClick;
                @SecondClick.started += instance.OnSecondClick;
                @SecondClick.performed += instance.OnSecondClick;
                @SecondClick.canceled += instance.OnSecondClick;
                @PointerDelta.started += instance.OnPointerDelta;
                @PointerDelta.performed += instance.OnPointerDelta;
                @PointerDelta.canceled += instance.OnPointerDelta;
                @PointerPosition.started += instance.OnPointerPosition;
                @PointerPosition.performed += instance.OnPointerPosition;
                @PointerPosition.canceled += instance.OnPointerPosition;
            }
        }
    }
    public PlacementActions @Placement => new PlacementActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IPlacementActions
    {
        void OnMainClick(InputAction.CallbackContext context);
        void OnSecondClick(InputAction.CallbackContext context);
        void OnPointerDelta(InputAction.CallbackContext context);
        void OnPointerPosition(InputAction.CallbackContext context);
    }
}
