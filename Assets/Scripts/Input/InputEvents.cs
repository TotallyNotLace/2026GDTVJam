using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputEvents : MonoBehaviour
{
    private InputSystem_Actions playerController;

    public UnityEvent<Vector2> directionalMotion;
    public UnityEvent<bool> shootPressed;

    private void Start()
    {
        playerController = new InputSystem_Actions();
        playerController.Player.Enable();

        playerController.Player.Move.performed += OnMovementInput;
        playerController.Player.Move.canceled += OnMovementInput;

        playerController.Player.Attack.performed += OnShootyPress;
        playerController.Player.Attack.canceled += OnShootyPress;

        Debug.Log("[ShipInputEvents] Input enabled for local player.");
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        directionalMotion?.Invoke(context.ReadValue<Vector2>());
    }

    private void OnShootyPress(InputAction.CallbackContext context)
    {
        shootPressed?.Invoke(context.performed);
    }

    private void OnDestroy()
    {
        if (playerController == null) return;

        playerController.Player.Move.performed -= OnMovementInput;
        playerController.Player.Move.canceled -= OnMovementInput;

        playerController.Player.Attack.performed -= OnShootyPress;
        playerController.Player.Attack.canceled -= OnShootyPress;

        playerController.Player.Disable();
    }
}
