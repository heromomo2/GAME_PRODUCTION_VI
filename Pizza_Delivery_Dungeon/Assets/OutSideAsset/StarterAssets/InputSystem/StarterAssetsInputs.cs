using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;
        public bool pickup;//add
        public bool roll;//add
        public bool switchcamera;//add

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
            Debug.Log(" OnMove was called");

        }

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
	//		Debug.Log(" OnSprint was called");
		}

		public void OnPickUp(InputValue value)
		{
			PickUpInput(value.isPressed);
	//		Debug.Log(" OnpickUP() was called");
		}

		public void OnRoll(InputValue value)
		{
			RollInput(value.isPressed);
		//  Debug.Log(" OnRoll() was called");
		}
		public void OnSwitchCamera(InputValue value)
		{
			SwitchCameraInput(value.isPressed);
			 //Debug.Log(" OnSwitchView() was called");
		}
#endif


        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        // add
        public void RollInput(bool newRollState)
        {
            roll = newRollState;
            //Debug.Log(" RollInput() was called");
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }
        // add
        public void PickUpInput(bool newPickUpState)
        {
            pickup = newPickUpState;
        }
        // add
        public void SwitchCameraInput(bool newSwitchCamera)
        {
            switchcamera = newSwitchCamera;
            // Debug.Log("  SwitchViewInputwas called");

        }
        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

}