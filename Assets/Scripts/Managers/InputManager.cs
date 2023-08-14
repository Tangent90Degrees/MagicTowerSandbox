using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{

    public static event Action<InputAction.CallbackContext> OnInteracting;

    private static void Interact(InputAction.CallbackContext context)
    {
        OnInteracting?.Invoke(context);
    }

    public static Vector2 Move { get; private set; }


    protected override void Awake()
    {
        _input = new InputControl();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Gameplay.Interact.started += Interact;
    }

    private void OnDisable()
    {
        _input.Gameplay.Interact.started -= Interact;
        _input.Disable();
    }

    private void Update()
    {
        Move = _input.Gameplay.Move.ReadValue<Vector2>();
    }

    
    private static InputControl _input;
    
}
