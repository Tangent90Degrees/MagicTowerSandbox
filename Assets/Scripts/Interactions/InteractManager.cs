using System;
using UnityEngine;

/// <summary>
/// The static manager of all interact actions in the game.
/// </summary>
public class InteractManager : Singleton<InteractManager>
{

    /// <summary>
    /// This event invokes when a new interaction is selected.
    /// </summary>
    public static event Action<IInteractive> OnInteractionSelected;


    /// <summary>
    /// This event invokes when interaction changed to not selected.
    /// </summary>
    public static event Action<IInteractive> OnInteractionUnselected;


    /// <summary>
    /// The selected interaction.
    /// Invokes selected interaction changed events when this property is set to a different reference.
    /// </summary>
    public static IInteractive SelectedInteraction
    {
        get => _selectedInteraction;
        set
        {
            if (value == _selectedInteraction) return;
            OnInteractionUnselected?.Invoke(_selectedInteraction);
            _selectedInteraction = value;
            OnInteractionSelected?.Invoke(_selectedInteraction);
        }
    }


    private void Update()
    {
        InteractionSelecting();

        if (Input.GetMouseButtonDown(0))
        {
            SelectedInteraction?.Interact();
        }
    }


    private void InteractionSelecting()
    {
        var interaction = CursorManager.ColliderOnCursor
            ? CursorManager.ColliderOnCursor.GetComponent<IInteractive>()
            : null;

        if (interaction == null)
        {
            SelectedInteraction = null;
        }
        else if (Vector2.Distance(interaction.Position, Player.Position) < interaction.MaxDistance)
        {
            SelectedInteraction = interaction;
        }
    }
    
    
    private static IInteractive _selectedInteraction;

}


/// <summary>
/// The interface of all interactive objects.
/// </summary>
public interface IInteractive
{
    
    /// <summary>
    /// The max distance between the player and this interaction that enables interacting.
    /// </summary>
    public float MaxDistance { get; }

    /// <summary>
    /// The world space position of its game object.
    /// </summary>
    public Vector2 Position { get; }
    
    /// <summary>
    /// This method is called once interacts.
    /// </summary>
    public void Interact();

}