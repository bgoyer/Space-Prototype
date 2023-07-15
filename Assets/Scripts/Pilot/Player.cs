using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using Unity.Mathematics;
using System;

public class Player : Pilot
{
    public Player(string name) : base (name) 
    { }

    PlayerInput input = null;
    Ship ship;

    bool accelerate = false;
    float accelerateModifier;
    bool turn = false;
    float turnModifier;
    bool tryReverseThrust = false;
    

    private void Awake()
    {
        input = new PlayerInput();
        ship = transform.GetComponent<Ship>();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Accelerate.performed += OnMovementPerformed;
        input.Player.Rotate.performed += OnRotatePerformed;
        input.Player.TryReverseThrust.performed += TryReverseThrust;
    }


    private void OnDisable()
    {
        input.Disable();
        input.Player.Accelerate.performed -= OnMovementPerformed;
        input.Player.Rotate.performed -= OnRotatePerformed;
        input.Player.TryReverseThrust.performed -= TryReverseThrust;
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
    private void TryReverseThrust(InputAction.CallbackContext input)
    {
        tryReverseThrust = !tryReverseThrust;
    }

    private void FixedUpdate()
    {
        if (accelerate)
        { 
            ship.Accelerate(accelerateModifier);
        }
        if (turn && !tryReverseThrust)
        {
            ship.Rotate(turnModifier);
        }
        if (tryReverseThrust)
        {
            if (ship.GetComponent<ReverseThruster>())
            {
                ship.GetComponent<ReverseThruster>().Thrust();
            }
            else
            {
                 ship.GetComponent<Turning>().RotateTowards(-ship.GetComponent<Rigidbody2D>().velocity);
            }
        }
    }
}
