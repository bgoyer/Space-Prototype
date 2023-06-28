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
    bool turn = false;


    private void Awake()
    {
        input = new PlayerInput();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Accelerate.performed += OnMovementPerformed;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Accelerate.performed -= OnMovementPerformed;
    }

    void OnMovementPerformed(InputAction.CallbackContext value)
    {
        accelerate = !accelerate;
    }

    private void FixedUpdate()
    {
        if (accelerate)
        {
            print("accerated");
            transform.parent.GetComponent<Ship>().Accelerate();
        }
    }
}
