using UnityEngine;

namespace Unity.FPS.Controls
{
    /// <summary>
    /// Input manager for controller-style inputs (with analogue sticks and buttons).
    /// </summary>
    public class GamepadInputManager : MonoBehaviour
    {
        // Gamepad input action map.
        private GamepadControls gameControls;

        /// <summary>
        /// Retrieve current state of analogue stick.
        /// </summary>
        public Vector2 AnalogueValueL { get; set; }

        
        /// <summary>
        /// Retrieve current state of analogue stick.
        /// </summary>
        public Vector2 AnalogueValueR { get; set; }


        public bool JumpButtonValue { get; set; }

        public bool CrouchButtonValue { get; private set; }

        public bool SwitchWeaponButtonValue { get; private set; }
        
        public bool ShootButtonValue { get; set; }
        
        public bool AimDownButtonValue { get; private set; }
        
        public bool RunButtonValue { get; set; }

        public bool SwitchWeaponNextButtonValue { get; private set; }

        public bool SwitchWeaponPreviousButtonValue { get; private set; }


        protected virtual void Awake()
        {
            gameControls = new GamepadControls();

            gameControls.gameplay.movement.performed += context => AnalogueValueL = context.ReadValue<Vector2>();
            gameControls.gameplay.movement.canceled += context => AnalogueValueL = Vector2.zero;


            gameControls.gameplay.look.performed += context => AnalogueValueR = context.ReadValue<Vector2>();
            gameControls.gameplay.look.canceled += context => AnalogueValueR = Vector2.zero;

            gameControls.gameplay.jump.performed +=
                context => JumpButtonValue = context.ReadValue<float>() > 0.5f;
            gameControls.gameplay.jump.canceled +=
                context => JumpButtonValue = false;

            gameControls.gameplay.shoot.performed +=
                context => ShootButtonValue = context.ReadValue<float>() > 0.5f;
            gameControls.gameplay.shoot.canceled +=
                context => ShootButtonValue = false;         
                
            gameControls.gameplay.crouch.performed +=
                context => CrouchButtonValue = context.ReadValue<float>() > 0.5f;
            gameControls.gameplay.crouch.canceled +=
                context => CrouchButtonValue = false;

            gameControls.gameplay.sprint.performed +=
                context => RunButtonValue = context.ReadValue<float>() > 0.5f;
            gameControls.gameplay.sprint.canceled +=
                context => RunButtonValue = false;
            
            gameControls.gameplay.aimdown.performed +=
                context => AimDownButtonValue = context.ReadValue<float>() > 0.5f;
            gameControls.gameplay.aimdown.canceled +=
                context => AimDownButtonValue = false;

            gameControls.gameplay.switchWeapon.performed +=
                context => SwitchWeaponButtonValue = context.ReadValue<float>() > 0.5f;
            gameControls.gameplay.switchWeapon.canceled +=
                context => SwitchWeaponButtonValue = false;
                
            gameControls.gameplay.switchWeaponPrevious.performed +=
                context => SwitchWeaponPreviousButtonValue = context.ReadValue<float>() > 0.5f;
            gameControls.gameplay.switchWeaponPrevious.canceled +=
                context => SwitchWeaponPreviousButtonValue = false;
                
            gameControls.gameplay.switchWeaponNext.performed +=
                context => SwitchWeaponNextButtonValue = context.ReadValue<float>() > 0.5f;
            gameControls.gameplay.switchWeaponNext.canceled +=
                context => SwitchWeaponNextButtonValue = false;
        }

        protected virtual void OnEnable()
        {
            gameControls?.Enable();
        }

        protected virtual void OnDisable()
        {
            gameControls?.Disable();
        }
    }
}
