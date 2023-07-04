using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player : Pilot
{
    Player(string name) : base (name) 
    { }

    PlayerInput input = null;
    private Vector2 movement = Vector2.zero;

    bool accelerate = false;
    float accelerateModifier;
    bool turn = false;
    float turnModifier;

    private void Awake()
    {
        input = new PlayerInput();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Accelerate.performed += OnMovementPerformed;
        input.Player.Rotate.performed += OnRotatePerformed;
    }


    private void OnDisable()
    {
        input.Disable();
        input.Player.Accelerate.performed -= OnMovementPerformed;
        input.Player.Rotate.performed -= OnRotatePerformed;
    }

    void OnMovementPerformed(InputAction.CallbackContext input)
    {
        accelerateModifier = input.ReadValue<float>();
        accelerate = !accelerate;
    }
    private void OnRotatePerformed(InputAction.CallbackContext input)
    {
        turnModifier = input.ReadValue<float>();
        turn = !turn;
    }

    private void FixedUpdate()
    {
        if (accelerate)
        { 
            transform.GetComponent<Ship>().Accelerate(accelerateModifier);
        }
        if (turn)
        {
            transform.GetComponent<Ship>().Rotate(turnModifier);
        }
    }
}
