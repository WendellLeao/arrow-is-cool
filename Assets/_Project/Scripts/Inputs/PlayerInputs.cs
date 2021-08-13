// GENERATED AUTOMATICALLY FROM 'Assets/_Project/InputActions/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""LandControls"",
            ""id"": ""fe380e61-3a69-49ab-b35d-715def31f095"",
            ""actions"": [
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4d0e47a5-335b-408e-840d-8405254c803f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2f812391-31e9-46e9-8dcf-acf9248688e1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""5a89f2fc-fd44-4db7-82ed-3f887dc0074e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""8c33014c-380e-4b66-8b10-3dd4367614bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""220fa20b-297e-49d7-ac3c-d1c0061a4064"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""89a318f8-4f84-41bc-a962-1738c535a4cb"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""40999651-2ad8-4112-a388-847cadd37391"",
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
                    ""id"": ""c70307cd-a42a-4078-980a-19cbd931f42a"",
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
                    ""id"": ""0bb37114-0210-4a62-a7b8-508180c2d0bc"",
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
                    ""id"": ""5a6b32f1-9e71-414c-ab9e-98ed61979f72"",
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
                    ""id"": ""ef8f000e-37bd-4908-a7e7-9973fc9628fc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f59965a6-842b-41bd-8011-0384efcb221f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8508f79f-525b-4e2f-bebc-68f064ac45cc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad41dfe8-5655-462f-8a7a-fb00d72a8d63"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Global"",
            ""id"": ""c2cd8422-0ff9-4a8c-9bfa-ebdd6bede5a3"",
            ""actions"": [
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""e923a9d0-6307-4049-b9bf-2cba9c21e2cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cbe8204c-72cd-49c7-922e-cb3fb712c9fe"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // LandControls
        m_LandControls = asset.FindActionMap("LandControls", throwIfNotFound: true);
        m_LandControls_MouseLook = m_LandControls.FindAction("MouseLook", throwIfNotFound: true);
        m_LandControls_Movement = m_LandControls.FindAction("Movement", throwIfNotFound: true);
        m_LandControls_Jump = m_LandControls.FindAction("Jump", throwIfNotFound: true);
        m_LandControls_Shoot = m_LandControls.FindAction("Shoot", throwIfNotFound: true);
        m_LandControls_Aim = m_LandControls.FindAction("Aim", throwIfNotFound: true);
        // Global
        m_Global = asset.FindActionMap("Global", throwIfNotFound: true);
        m_Global_PauseGame = m_Global.FindAction("PauseGame", throwIfNotFound: true);
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

    // LandControls
    private readonly InputActionMap m_LandControls;
    private ILandControlsActions m_LandControlsActionsCallbackInterface;
    private readonly InputAction m_LandControls_MouseLook;
    private readonly InputAction m_LandControls_Movement;
    private readonly InputAction m_LandControls_Jump;
    private readonly InputAction m_LandControls_Shoot;
    private readonly InputAction m_LandControls_Aim;
    public struct LandControlsActions
    {
        private @PlayerInputs m_Wrapper;
        public LandControlsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseLook => m_Wrapper.m_LandControls_MouseLook;
        public InputAction @Movement => m_Wrapper.m_LandControls_Movement;
        public InputAction @Jump => m_Wrapper.m_LandControls_Jump;
        public InputAction @Shoot => m_Wrapper.m_LandControls_Shoot;
        public InputAction @Aim => m_Wrapper.m_LandControls_Aim;
        public InputActionMap Get() { return m_Wrapper.m_LandControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LandControlsActions set) { return set.Get(); }
        public void SetCallbacks(ILandControlsActions instance)
        {
            if (m_Wrapper.m_LandControlsActionsCallbackInterface != null)
            {
                @MouseLook.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMouseLook;
                @Movement.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnJump;
                @Shoot.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnShoot;
                @Aim.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_LandControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public LandControlsActions @LandControls => new LandControlsActions(this);

    // Global
    private readonly InputActionMap m_Global;
    private IGlobalActions m_GlobalActionsCallbackInterface;
    private readonly InputAction m_Global_PauseGame;
    public struct GlobalActions
    {
        private @PlayerInputs m_Wrapper;
        public GlobalActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseGame => m_Wrapper.m_Global_PauseGame;
        public InputActionMap Get() { return m_Wrapper.m_Global; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GlobalActions set) { return set.Get(); }
        public void SetCallbacks(IGlobalActions instance)
        {
            if (m_Wrapper.m_GlobalActionsCallbackInterface != null)
            {
                @PauseGame.started -= m_Wrapper.m_GlobalActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_GlobalActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_GlobalActionsCallbackInterface.OnPauseGame;
            }
            m_Wrapper.m_GlobalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
            }
        }
    }
    public GlobalActions @Global => new GlobalActions(this);
    public interface ILandControlsActions
    {
        void OnMouseLook(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
    public interface IGlobalActions
    {
        void OnPauseGame(InputAction.CallbackContext context);
    }
}
