using Unity.FPS.Game;
using UnityEngine;
using Unity.FPS.Controls;

namespace Unity.FPS.Gameplay
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [Tooltip("Sensitivity multiplier for moving the camera around")]
        public float LookSensitivity = 1f;

        [Tooltip("Additional sensitivity multiplier for WebGL")]
        public float WebglLookSensitivityMultiplier = 0.25f;

        [Tooltip("Limit to consider an input when using a trigger on a controller")]
        public float TriggerAxisThreshold = 0.4f;

        [Tooltip("Used to flip the vertical input axis")]
        public bool InvertYAxis = false;

        [Tooltip("Used to flip the horizontal input axis")]
        public bool InvertXAxis = false;

        GameFlowManager m_GameFlowManager;
        PlayerCharacterController m_PlayerCharacterController;
        bool m_FireInputWasHeld;

        [SerializeField]
        private GamepadInputManager inputManager;

        void Start()
        {
            m_PlayerCharacterController = GetComponent<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullGetComponent<PlayerCharacterController, PlayerInputHandler>(
                m_PlayerCharacterController, this, gameObject);
            m_GameFlowManager = FindObjectOfType<GameFlowManager>();
            DebugUtility.HandleErrorIfNullFindObject<GameFlowManager, PlayerInputHandler>(m_GameFlowManager, this);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void LateUpdate()
        {
            m_FireInputWasHeld = GetFireInputHeld();
        }

        public bool CanProcessInput()
        {
            return Cursor.lockState == CursorLockMode.Locked && !m_GameFlowManager.GameIsEnding;
        }

        public Vector3 GetMoveInput()
        {
            if (CanProcessInput())
            {
                Vector3 move = new Vector3(inputManager.AnalogueValueL.x, 0f,
                    inputManager.AnalogueValueL.y);

                // constrain move input to a maximum magnitude of 1, otherwise diagonal movement might exceed the max move speed defined
                move = Vector3.ClampMagnitude(move, 1);

                return move;
            }

            return Vector3.zero;
        }

        public float GetLookInputsHorizontal()
        {
            return GetMouseOrStickLookAxis(inputManager.AnalogueValueR.x);
        }

        public float GetLookInputsVertical()
        {
            float direction = InvertYAxis ? -1 : 1;

            return  GetMouseOrStickLookAxis(inputManager.AnalogueValueR.y) * direction;
        }

        public bool GetJumpInputDown()
        {
            if (CanProcessInput())
            {
                return inputManager.JumpButtonValue == true;
            }

            return false;
        }

        public bool GetJumpInputHeld()
        {
            if (CanProcessInput())
            {
                return inputManager.JumpButtonValue == true;
            }

            return false;
        }

        public bool GetFireInputDown()
        {
            return GetFireInputHeld() && !m_FireInputWasHeld;
        }

        public bool GetFireInputReleased()
        {
            return !GetFireInputHeld() && m_FireInputWasHeld;
        }

        public bool GetFireInputHeld()
        {
            if (CanProcessInput())
            {
               return inputManager.ShootButtonValue == true;
            }

            return false;
        }

        public bool GetAimInputHeld()
        {
            if (CanProcessInput())
            {
                return inputManager.AimDownButtonValue == true;
            }

            return false;
        }

        public bool GetSprintInputHeld()
        {
            if (CanProcessInput())
            {
                return inputManager.RunButtonValue == true;
            }

            return false;
        }

        public bool GetCrouchInputDown()
        {
            if (CanProcessInput())
            {
                return inputManager.CrouchButtonValue == true;
            }

            return false;
        }

        public bool GetCrouchInputReleased()
        {
            if (CanProcessInput())
            {
                return inputManager.CrouchButtonValue == false;
            }

            return false;
        }

        public bool GetReloadButtonDown()
        {
            if (CanProcessInput())
            {
                return Input.GetButtonDown(GameConstants.k_ButtonReload);
            }

            return false;
        }

        public int GetSwitchWeaponInput()
        {
            if (CanProcessInput())
            {
                if (inputManager.SwitchWeaponButtonValue == true)
                    return -1;
                else if (inputManager.SwitchWeaponNextButtonValue == true)
                    return -1;
                else if (inputManager.SwitchWeaponPreviousButtonValue == true)
                    return 1;
            }

            return 0;
        }

        public int GetSelectWeaponInput()
        {
            if (CanProcessInput())
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                    return 1;
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                    return 2;
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                    return 3;
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                    return 4;
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                    return 5;
                else if (Input.GetKeyDown(KeyCode.Alpha6))
                    return 6;
                else if (Input.GetKeyDown(KeyCode.Alpha7))
                    return 7;
                else if (Input.GetKeyDown(KeyCode.Alpha8))
                    return 8;
                else if (Input.GetKeyDown(KeyCode.Alpha9))
                    return 9;
                else
                    return 0;
            }

            return 0;
        }

        float GetMouseOrStickLookAxis(float axisValue)
        {
            if (CanProcessInput())
            {
                
                float i = axisValue;

                // apply sensitivity multiplier
                i *= LookSensitivity;

                i *= Time.deltaTime;

                return i;
            }

            return 0f;
        }
    }
}