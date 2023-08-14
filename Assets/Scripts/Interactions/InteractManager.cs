using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// The static manager of all interact actions in the game.
/// </summary>
public class InteractManager : Singleton<InteractManager>
{

    /// <summary>
    /// The selected interaction.
    /// Invokes selected interaction changed events when this property is set to a different reference.
    /// </summary>
    public static Interaction SelectedInteraction { get; private set; }
    
    public static GameObject Player => GameManager.Player.gameObject;


    private void Interact(InputAction.CallbackContext _)
    {
        SelectedInteraction?.Interact();
    }

    public static void Select(Interaction interaction)
    {
        if (_selectedInteractions.Contains(interaction)) return;
        _selectedInteractions.Add(interaction);

        SelectedInteraction?.OnUnselected();
        SelectedInteraction = interaction;
        SelectedInteraction.OnSelected();
    }

    public static void Unselect(Interaction interaction)
    {
        if (interaction == SelectedInteraction)
        {
            _selectedInteractions.Remove(interaction);

            SelectedInteraction.OnUnselected();
            SelectedInteraction = _selectedInteractions.Count == 0 ? null : _selectedInteractions[^1];
            SelectedInteraction?.OnSelected();
        }
        else
        {
            _selectedInteractions.Remove(interaction);
        }
    }


    private void OnEnable()
    {
        InputManager.OnInteracting += Interact;
    }

    private void OnDisable()
    {
        InputManager.OnInteracting -= Interact;
    }
    
    
    private static readonly List<Interaction> _selectedInteractions = new();

}