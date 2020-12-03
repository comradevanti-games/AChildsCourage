// GENERATED AUTOMATICALLY FROM 'Assets/Misc/user.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Object = UnityEngine.Object;

namespace AChildsCourage.Game.Input
{

    public class UserControls : IInputActionCollection, IDisposable
    {

        // Player
        private readonly InputActionMap mPlayer;
        private readonly InputAction mPlayerItem1;
        private readonly InputAction mPlayerItem2;
        private readonly InputAction mPlayerLook;
        private readonly InputAction mPlayerMove;
        private readonly InputAction mPlayerSwap;

        // UI
        private readonly InputActionMap mUI;
        private readonly InputAction mUICancel;
        private readonly InputAction mUILeftClick;
        private readonly InputAction mUINavigation;
        private readonly InputAction mUIPoint;
        private readonly InputAction mUIQuit;
        private readonly InputAction mUIRightClick;
        private readonly InputAction mUISubmit;
        private int mGamepadSchemeIndex = -1;
        private int mJoystickSchemeIndex = -1;
        private int mKeyboardMouseSchemeIndex = -1;
        private IPlayerActions mPlayerActionsCallbackInterface;
        private int mTouchSchemeIndex = -1;
        private IUIActions mUIActionsCallbackInterface;
        private int mXRSchemeIndex = -1;

        public InputActionAsset Asset { get; }

        public PlayerActions Player => new PlayerActions(this);

        public UIActions UI => new UIActions(this);

        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (mKeyboardMouseSchemeIndex == -1)
                    mKeyboardMouseSchemeIndex = Asset.FindControlSchemeIndex("Keyboard&Mouse");
                return Asset.controlSchemes[mKeyboardMouseSchemeIndex];
            }
        }

        public InputControlScheme GamepadScheme
        {
            get
            {
                if (mGamepadSchemeIndex == -1)
                    mGamepadSchemeIndex = Asset.FindControlSchemeIndex("Gamepad");
                return Asset.controlSchemes[mGamepadSchemeIndex];
            }
        }

        public InputControlScheme TouchScheme
        {
            get
            {
                if (mTouchSchemeIndex == -1)
                    mTouchSchemeIndex = Asset.FindControlSchemeIndex("Touch");
                return Asset.controlSchemes[mTouchSchemeIndex];
            }
        }

        public InputControlScheme JoystickScheme
        {
            get
            {
                if (mJoystickSchemeIndex == -1)
                    mJoystickSchemeIndex = Asset.FindControlSchemeIndex("Joystick");
                return Asset.controlSchemes[mJoystickSchemeIndex];
            }
        }

        public InputControlScheme XRScheme
        {
            get
            {
                if (mXRSchemeIndex == -1)
                    mXRSchemeIndex = Asset.FindControlSchemeIndex("XR");
                return Asset.controlSchemes[mXRSchemeIndex];
            }
        }

        public UserControls()
        {
            Asset = InputActionAsset.FromJson(@"{
    ""name"": ""user"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""225e873a-7cc3-41d7-839a-bc118469c640"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6a8eb874-78a3-4568-95b5-5ae49922ad53"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""aa173f46-23d1-441a-bab6-a9f457fb77a8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item1"",
                    ""type"": ""Button"",
                    ""id"": ""7d2e1401-9d8c-4294-a8e3-44f8e67d8311"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.6),Press(behavior=2)""
                },
                {
                    ""name"": ""Item2"",
                    ""type"": ""Button"",
                    ""id"": ""918a9149-4af6-48b2-9095-084b814f9be4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.6),Press(behavior=2)""
                },
                {
                    ""name"": ""Swap"",
                    ""type"": ""Button"",
                    ""id"": ""2b242a65-6c96-479c-a9fa-2ddc1c888fce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""e4e1d1a3-31d4-4b1a-ae29-1bb31c5d33b1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fa1a88d7-2bac-469e-93d6-9d4c05baaf8a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1ef5ec19-9e00-4f24-ba9b-bf33811fdb2a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4d8e7b49-812e-41d2-921e-0d6ad7df73d5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4be32472-e201-4d7a-82d5-c84ca60f7c28"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""28315ec3-c052-41d4-9e1c-535d9eb47fd0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a884d1f-bec2-4aab-b1e0-aaa01daae1ea"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Item1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03674e48-5055-4e76-8e11-e63e59a47fd9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Item2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9b019a4-d0c7-4942-a4b5-a164d83e3721"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""2b0f8e79-fd15-409f-9298-d54482ee588d"",
            ""actions"": [
                {
                    ""name"": ""Navigation"",
                    ""type"": ""Button"",
                    ""id"": ""fdbc710b-c574-4e17-9962-89f44270aba0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""da179f4b-817b-4adb-bfe0-89b93fc63500"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""09e6ec82-20ea-45df-952b-9fad9c81d797"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""33c298a4-27bb-4463-842a-ba27433fbff7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c6e48bfd-8e54-4811-8d04-82d4cac1e2ee"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""93d38261-077a-477d-ba03-74dd6e555764"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b74d359b-bded-42cb-b941-6d2971f34cfc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""9fefd307-4979-4b22-b5b3-c4dd4d57442d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e30a9814-aff0-4c67-8948-b33f0db64a1c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f1116fc1-6281-4d83-9515-5bad06a66b30"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""47f9f502-b477-44e8-b260-ce6f0d1d5573"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cba93cf7-aa60-44bc-a7da-d3af318aea3b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1f9a88f7-1170-48e0-abc4-d2eab164e720"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b4521aba-e4ed-4773-83ea-9b0d8a1640ac"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f2f8ac8a-e56a-4a96-a6e5-ff4417b97313"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""009ab7c4-d12a-4e3f-a20c-eb449f136f6f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5aff9a53-bfb7-448c-b2cc-054b80336556"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e756701f-f558-423e-b27a-05266ca523d6"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee1d9071-7594-4e82-b84f-4947dc645b06"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""696d3df6-720e-4363-9cbd-503386bd9a74"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c630d214-37a0-4138-b82a-f1f71e2a1a45"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef2bca31-8e61-41e0-a1ef-7c3a0bff336c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb205132-4c7c-460a-a022-163c4de0a037"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");

            // Player
            mPlayer = Asset.FindActionMap("Player", true);
            mPlayerMove = mPlayer.FindAction("Move", true);
            mPlayerLook = mPlayer.FindAction("Look", true);
            mPlayerItem1 = mPlayer.FindAction("Item1", true);
            mPlayerItem2 = mPlayer.FindAction("Item2", true);
            mPlayerSwap = mPlayer.FindAction("Swap", true);

            // UI
            mUI = Asset.FindActionMap("UI", true);
            mUINavigation = mUI.FindAction("Navigation", true);
            mUISubmit = mUI.FindAction("Submit", true);
            mUICancel = mUI.FindAction("Cancel", true);
            mUIQuit = mUI.FindAction("Quit", true);
            mUIPoint = mUI.FindAction("Point", true);
            mUILeftClick = mUI.FindAction("LeftClick", true);
            mUIRightClick = mUI.FindAction("RightClick", true);
        }

        public void Dispose()
        {
            Object.Destroy(Asset);
        }

        public InputBinding? bindingMask { get => Asset.bindingMask; set => Asset.bindingMask = value; }

        public ReadOnlyArray<InputDevice>? devices { get => Asset.devices; set => Asset.devices = value; }

        public ReadOnlyArray<InputControlScheme> controlSchemes => Asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return Asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return Asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            Asset.Enable();
        }

        public void Disable()
        {
            Asset.Disable();
        }

        public struct PlayerActions
        {

            private readonly UserControls mWrapper;

            public PlayerActions(UserControls wrapper)
            {
                mWrapper = wrapper;
            }

            public InputAction Move => mWrapper.mPlayerMove;

            public InputAction Look => mWrapper.mPlayerLook;

            public InputAction Item1 => mWrapper.mPlayerItem1;

            public InputAction Item2 => mWrapper.mPlayerItem2;

            public InputAction Swap => mWrapper.mPlayerSwap;

            public InputActionMap Get()
            {
                return mWrapper.mPlayer;
            }

            public void Enable()
            {
                Get()
                    .Enable();
            }

            public void Disable()
            {
                Get()
                    .Disable();
            }

            public bool Enabled =>
                Get()
                    .enabled;

            public static implicit operator InputActionMap(PlayerActions set)
            {
                return set.Get();
            }

            public void SetCallbacks(IPlayerActions instance)
            {
                if (mWrapper.mPlayerActionsCallbackInterface != null)
                {
                    Move.started -= mWrapper.mPlayerActionsCallbackInterface.OnMove;
                    Move.performed -= mWrapper.mPlayerActionsCallbackInterface.OnMove;
                    Move.canceled -= mWrapper.mPlayerActionsCallbackInterface.OnMove;
                    Look.started -= mWrapper.mPlayerActionsCallbackInterface.OnLook;
                    Look.performed -= mWrapper.mPlayerActionsCallbackInterface.OnLook;
                    Look.canceled -= mWrapper.mPlayerActionsCallbackInterface.OnLook;
                    Item1.started -= mWrapper.mPlayerActionsCallbackInterface.OnItem1;
                    Item1.performed -= mWrapper.mPlayerActionsCallbackInterface.OnItem1;
                    Item1.canceled -= mWrapper.mPlayerActionsCallbackInterface.OnItem1;
                    Item2.started -= mWrapper.mPlayerActionsCallbackInterface.OnItem2;
                    Item2.performed -= mWrapper.mPlayerActionsCallbackInterface.OnItem2;
                    Item2.canceled -= mWrapper.mPlayerActionsCallbackInterface.OnItem2;
                    Swap.started -= mWrapper.mPlayerActionsCallbackInterface.OnSwap;
                    Swap.performed -= mWrapper.mPlayerActionsCallbackInterface.OnSwap;
                    Swap.canceled -= mWrapper.mPlayerActionsCallbackInterface.OnSwap;
                }

                mWrapper.mPlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    Move.started += instance.OnMove;
                    Move.performed += instance.OnMove;
                    Move.canceled += instance.OnMove;
                    Look.started += instance.OnLook;
                    Look.performed += instance.OnLook;
                    Look.canceled += instance.OnLook;
                    Item1.started += instance.OnItem1;
                    Item1.performed += instance.OnItem1;
                    Item1.canceled += instance.OnItem1;
                    Item2.started += instance.OnItem2;
                    Item2.performed += instance.OnItem2;
                    Item2.canceled += instance.OnItem2;
                    Swap.started += instance.OnSwap;
                    Swap.performed += instance.OnSwap;
                    Swap.canceled += instance.OnSwap;
                }
            }

        }

        public struct UIActions
        {

            private readonly UserControls mWrapper;

            public UIActions(UserControls wrapper)
            {
                mWrapper = wrapper;
            }

            public InputAction Navigation => mWrapper.mUINavigation;

            public InputAction Submit => mWrapper.mUISubmit;

            public InputAction Cancel => mWrapper.mUICancel;

            public InputAction Quit => mWrapper.mUIQuit;

            public InputAction Point => mWrapper.mUIPoint;

            public InputAction LeftClick => mWrapper.mUILeftClick;

            public InputAction RightClick => mWrapper.mUIRightClick;

            public InputActionMap Get()
            {
                return mWrapper.mUI;
            }

            public void Enable()
            {
                Get()
                    .Enable();
            }

            public void Disable()
            {
                Get()
                    .Disable();
            }

            public bool Enabled =>
                Get()
                    .enabled;

            public static implicit operator InputActionMap(UIActions set)
            {
                return set.Get();
            }

            public void SetCallbacks(IUIActions instance)
            {
                if (mWrapper.mUIActionsCallbackInterface != null)
                {
                    Navigation.started -= mWrapper.mUIActionsCallbackInterface.OnNavigation;
                    Navigation.performed -= mWrapper.mUIActionsCallbackInterface.OnNavigation;
                    Navigation.canceled -= mWrapper.mUIActionsCallbackInterface.OnNavigation;
                    Submit.started -= mWrapper.mUIActionsCallbackInterface.OnSubmit;
                    Submit.performed -= mWrapper.mUIActionsCallbackInterface.OnSubmit;
                    Submit.canceled -= mWrapper.mUIActionsCallbackInterface.OnSubmit;
                    Cancel.started -= mWrapper.mUIActionsCallbackInterface.OnCancel;
                    Cancel.performed -= mWrapper.mUIActionsCallbackInterface.OnCancel;
                    Cancel.canceled -= mWrapper.mUIActionsCallbackInterface.OnCancel;
                    Quit.started -= mWrapper.mUIActionsCallbackInterface.OnQuit;
                    Quit.performed -= mWrapper.mUIActionsCallbackInterface.OnQuit;
                    Quit.canceled -= mWrapper.mUIActionsCallbackInterface.OnQuit;
                    Point.started -= mWrapper.mUIActionsCallbackInterface.OnPoint;
                    Point.performed -= mWrapper.mUIActionsCallbackInterface.OnPoint;
                    Point.canceled -= mWrapper.mUIActionsCallbackInterface.OnPoint;
                    LeftClick.started -= mWrapper.mUIActionsCallbackInterface.OnLeftClick;
                    LeftClick.performed -= mWrapper.mUIActionsCallbackInterface.OnLeftClick;
                    LeftClick.canceled -= mWrapper.mUIActionsCallbackInterface.OnLeftClick;
                    RightClick.started -= mWrapper.mUIActionsCallbackInterface.OnRightClick;
                    RightClick.performed -= mWrapper.mUIActionsCallbackInterface.OnRightClick;
                    RightClick.canceled -= mWrapper.mUIActionsCallbackInterface.OnRightClick;
                }

                mWrapper.mUIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    Navigation.started += instance.OnNavigation;
                    Navigation.performed += instance.OnNavigation;
                    Navigation.canceled += instance.OnNavigation;
                    Submit.started += instance.OnSubmit;
                    Submit.performed += instance.OnSubmit;
                    Submit.canceled += instance.OnSubmit;
                    Cancel.started += instance.OnCancel;
                    Cancel.performed += instance.OnCancel;
                    Cancel.canceled += instance.OnCancel;
                    Quit.started += instance.OnQuit;
                    Quit.performed += instance.OnQuit;
                    Quit.canceled += instance.OnQuit;
                    Point.started += instance.OnPoint;
                    Point.performed += instance.OnPoint;
                    Point.canceled += instance.OnPoint;
                    LeftClick.started += instance.OnLeftClick;
                    LeftClick.performed += instance.OnLeftClick;
                    LeftClick.canceled += instance.OnLeftClick;
                    RightClick.started += instance.OnRightClick;
                    RightClick.performed += instance.OnRightClick;
                    RightClick.canceled += instance.OnRightClick;
                }
            }

        }

        public interface IPlayerActions
        {

            void OnMove(InputAction.CallbackContext context);

            void OnLook(InputAction.CallbackContext context);

            void OnItem1(InputAction.CallbackContext context);

            void OnItem2(InputAction.CallbackContext context);

            void OnSwap(InputAction.CallbackContext context);

        }

        public interface IUIActions
        {

            void OnNavigation(InputAction.CallbackContext context);

            void OnSubmit(InputAction.CallbackContext context);

            void OnCancel(InputAction.CallbackContext context);

            void OnQuit(InputAction.CallbackContext context);

            void OnPoint(InputAction.CallbackContext context);

            void OnLeftClick(InputAction.CallbackContext context);

            void OnRightClick(InputAction.CallbackContext context);

        }

    }

}