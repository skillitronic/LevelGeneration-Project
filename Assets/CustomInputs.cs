// GENERATED AUTOMATICALLY FROM 'Assets/CustomInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CustomInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CustomInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CustomInputs"",
    ""maps"": [
        {
            ""name"": ""SpawnController"",
            ""id"": ""05217758-a52c-4f32-901d-14c49de2d7f7"",
            ""actions"": [
                {
                    ""name"": ""KeyBoard"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5a128e00-ae22-4664-8357-91ba8507f39f"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f7039cf6-3f8f-428c-9f26-6610a03500d1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyBoard"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fd4cb8aa-3083-480e-8a5e-2131676785a0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyBoard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f8b77882-faed-4d12-aab6-eedec28ca565"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyBoard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c8adbd19-4851-49a5-8c26-457a3de6d729"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyBoard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""98e4c34c-c8ed-48df-bb0d-01e8663884da"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyBoard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // SpawnController
        m_SpawnController = asset.FindActionMap("SpawnController", throwIfNotFound: true);
        m_SpawnController_KeyBoard = m_SpawnController.FindAction("KeyBoard", throwIfNotFound: true);
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

    // SpawnController
    private readonly InputActionMap m_SpawnController;
    private ISpawnControllerActions m_SpawnControllerActionsCallbackInterface;
    private readonly InputAction m_SpawnController_KeyBoard;
    public struct SpawnControllerActions
    {
        private @CustomInputs m_Wrapper;
        public SpawnControllerActions(@CustomInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @KeyBoard => m_Wrapper.m_SpawnController_KeyBoard;
        public InputActionMap Get() { return m_Wrapper.m_SpawnController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpawnControllerActions set) { return set.Get(); }
        public void SetCallbacks(ISpawnControllerActions instance)
        {
            if (m_Wrapper.m_SpawnControllerActionsCallbackInterface != null)
            {
                @KeyBoard.started -= m_Wrapper.m_SpawnControllerActionsCallbackInterface.OnKeyBoard;
                @KeyBoard.performed -= m_Wrapper.m_SpawnControllerActionsCallbackInterface.OnKeyBoard;
                @KeyBoard.canceled -= m_Wrapper.m_SpawnControllerActionsCallbackInterface.OnKeyBoard;
            }
            m_Wrapper.m_SpawnControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @KeyBoard.started += instance.OnKeyBoard;
                @KeyBoard.performed += instance.OnKeyBoard;
                @KeyBoard.canceled += instance.OnKeyBoard;
            }
        }
    }
    public SpawnControllerActions @SpawnController => new SpawnControllerActions(this);
    public interface ISpawnControllerActions
    {
        void OnKeyBoard(InputAction.CallbackContext context);
    }
}
