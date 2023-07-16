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
    bool reverseThrust = false;
    bool shoot = false;
    

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
        input.Player.TryReverseThrust.performed += OnReverseThrustPerformed;
        input.Player.Shoot.performed += OnShootPerformed;
    }


    private void OnDisable()
    {
        input.Disable();
        input.Player.Accelerate.performed -= OnMovementPerformed;
        input.Player.Rotate.performed -= OnRotatePerformed;
        input.Player.TryReverseThrust.performed -= OnReverseThrustPerformed;
        input.Player.Shoot.performed -= OnShootPerformed;
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
    private void OnReverseThrustPerformed(InputAction.CallbackContext input)
    {
        reverseThrust = !reverseThrust;
    }
    private void OnShootPerformed(InputAction.CallbackContext input)
    {
        shoot = !shoot;
    }

    private void FixedUpdate()
    {
        if (accelerate)
        { 
            ship.Accelerate(accelerateModifier);
        }
        if (turn && !reverseThrust)
        {
            ship.Rotate(turnModifier);
        }
        if (reverseThrust)
        {
            if (ship.GetComponent<ReverseThruster>())
            {
                ship.GetComponent<ReverseThruster>().Thrust();
            }
            else
            {
                 ship.GetComponent<Turning>().RotateTowards(ship.GetComponent<Rigidbody2D>().velocity);
            }
        }
        if (shoot)
        {
            foreach (var weapon in ship.GetComponents<Weapon>())
            {
                weapon.Fire();
            }
        }
    }
}
