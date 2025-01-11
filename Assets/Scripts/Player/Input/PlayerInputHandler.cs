using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 _rawMovementInput;
    public int NormInputX { get; private set; }
    public bool JumpPressed { get; private set; }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        _rawMovementInput = context.ReadValue<Vector2>();
        
        NormInputX = (int)(_rawMovementInput * Vector2.right).normalized.x;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            JumpPressed = true;
        }
        else if (context.canceled)
        {
            JumpPressed = false;
        }
    }
}
