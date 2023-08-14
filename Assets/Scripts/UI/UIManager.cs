using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// The manager of all UI events.
/// </summary>
public class UIManager : Singleton<UIManager>
{

    /// <summary>
    /// The selected UI block.
    /// </summary>
    public static UIBlock SelectedBlock
    {
        get => _selectedBlock;
        set
        {
            _selectedBlock?.Unselect();
            _selectedBlock = value;
            _selectedBlock?.Select();
        }
    }

    private void Interact(InputAction.CallbackContext _)
    {
        SelectedBlock?.Interact();
    }


    private void OnEnable()
    {
        InputManager.OnInteracting += Interact;
    }

    private void OnDisable()
    {
        InputManager.OnInteracting -= Interact;
    }
    
    
    private static UIBlock _selectedBlock;

}
