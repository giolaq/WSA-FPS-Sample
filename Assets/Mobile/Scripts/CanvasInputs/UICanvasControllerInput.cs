using UnityEngine;
using Unity.FPS.Controls;

namespace Unity.FPS
{
    public class UICanvasControllerInput : MonoBehaviour
    {
        [Tooltip("Sensitivity multiplier for moving the camera around")]
        public float LookSensitivity = 1f;

        [Header("Output")]
        public GamepadInputManager gamepadInputManager;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            gamepadInputManager.AnalogueValueL = virtualMoveDirection;
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            gamepadInputManager.AnalogueValueR = virtualLookDirection * LookSensitivity;
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            gamepadInputManager.JumpButtonValue = virtualJumpState;
        }

        public void VirtualFireInput(bool virtualFireState)
        {
            gamepadInputManager.ShootButtonValue = virtualFireState;
        }
        
    }

}
