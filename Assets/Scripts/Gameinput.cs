using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gameinput : MonoBehaviour
{
    public static Gameinput Instance { get; private set; }

    private Playerinputaction _playerInputActions;
   
    public event EventHandler OnPlayerDash;
    public event EventHandler OnPlayerBlock;
    private void Awake()
    {
            Instance = this;
      
        _playerInputActions = new Playerinputaction();
        _playerInputActions.Enable();

        _playerInputActions.Player.Dash.performed += PlayerDash_performed;
        _playerInputActions.Player.Block.started += PlayerBlock_performed;
    }

    private void PlayerDash_performed(InputAction.CallbackContext context)
    {
        OnPlayerDash?.Invoke(this, EventArgs.Empty);
    }
    private void PlayerBlock_performed(InputAction.CallbackContext context)
    {
        OnPlayerBlock?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        return mousePos;
    }
    public bool IsAttacking()
    {
        return _playerInputActions.Player.Attack.triggered;
    }
    public bool IsBlocking()
    {

        return _playerInputActions.Player.Block.triggered;
    }
    public void DiseableMovement()
    {
        _playerInputActions.Disable();
    }

}
