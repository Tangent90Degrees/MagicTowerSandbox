using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The static manager of all interact actions in the game.
/// </summary>
public class InteractManager : Singleton<InteractManager>
{

    /// <summary>
    /// This event invokes when a new interaction is selected.
    /// </summary>
    public static event Action<IInteractive> OnInteractionSlected;


    /// <summary>
    /// This event invokes when interaction changed to not selected.
    /// </summary>
    public static event Action<IInteractive> OnInteractionUnslected;


    /// <summary>
    /// The selected interaction.
    /// Invokes selected interaction changed events when this property is set to a different reference.
    /// </summary>
    public static IInteractive SelectedInteraction
    {
        get => _selectedInteraction;
        set
        {
            if (value != _selectedInteraction)
            {
                OnInteractionUnslected?.Invoke(_selectedInteraction);
                _selectedInteraction = value;
                OnInteractionSlected?.Invoke(_selectedInteraction);
            }
        }
    }


    /// <summary>
    /// Call Interact method of SelectedInteraction.
    /// </summary>
    public static void Interact()
    {
        SelectedInteraction?.Interact();
    }


    private void Update()
    {
        InteractionSelecting();

        if (Input.GetMouseButtonDown(0))
        {
            Interact();
        }
    }


    private void InteractionSelecting()
    {
        IInteractive interactionAtCursorPosition = CursorManager.ColliderOnCursor ? CursorManager.ColliderOnCursor.GetComponent<IInteractive>() : null;

        if (interactionAtCursorPosition == null)
        {
            SelectedInteraction = null;
        }
        else if (Vector3.Distance(interactionAtCursorPosition.transform.position, Player.Position) < _maxInteractingDistance)
        {
            SelectedInteraction = interactionAtCursorPosition;
        }
    }


    #region On Inspector

    [SerializeField] private float _maxInteractingDistance;

    #endregion


    private static IInteractive _selectedInteraction;

}


/// <summary>
/// The interface of all interactive objects.
/// </summary>
public interface IInteractive
{
    
    public Transform transform { get; }

    /// <summary>
    /// This method is called once interacts.
    /// </summary>
    public void Interact();

}