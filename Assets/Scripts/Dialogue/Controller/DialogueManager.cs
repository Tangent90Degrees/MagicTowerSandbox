
using System;
using UnityEngine;

/// <summary>
/// The manager of dialogue processing.
/// </summary>
public class DialogueManager : Singleton<DialogueManager>
{

    public static event Action<DialogueTurn> OnTurnLoaded;

    /// <summary>
    /// The current dialogue is displaying.
    /// Set to null to end current dialogue.
    /// </summary>
    public static DialogueData Dialogue
    {
        get => _dialogue;
        set
        {
            _dialogue = value;
            TurnIndex = 0;
        }
    }

    /// <summary>
    /// The current dialogue turn.
    /// </summary>
    public static DialogueTurn Turn
    {
        get => _turn;
        private set
        {
            _turn = value;
            OnTurnLoaded?.Invoke(Turn);
        }
    }

    /// <summary>
    /// The index of current turn in the dialogue.
    /// Auto set turn when changed value.
    /// </summary>
    public static int TurnIndex
    {
        get => _turnIndex;
        set
        {
            if (IsDuringDialogue)
            {
                _turnIndex = value;
                Turn = Dialogue.Turns[TurnIndex];
            }
            else
            {
                _turnIndex = 0;
                Turn = null;
            }
        }
    }

    public static bool IsLastTurn => IsDuringDialogue && TurnIndex == Dialogue.Turns.Count - 1;

    public static bool IsSelectingOption => IsLastTurn && !Dialogue.Ends;
    public static bool Ends => IsLastTurn && Dialogue.Ends;


    public static bool IsDuringDialogue => Dialogue;


    public static DialogueOption SelectedOption
    {
        get => _selectedOption;
        set => _selectedOption = value;
    }


    private void Update()
    {
        if (IsDuringDialogue && Input.GetButtonDown("Interact"))
        {
            Push();
        }
    }


    private static void Push()
    {
        if (IsSelectingOption)
        {
            Dialogue = SelectedOption.NextDialogue;
        }
        else if (Ends)
        {
            Dialogue = null;
        }
        else
        {
            TurnIndex++;
        }
    }


    private static DialogueData _dialogue;
    private static DialogueTurn _turn;
    private static int _turnIndex;
    private static DialogueOption _selectedOption;


    private void Start()
    {
        Dialogue = _test;
    }

    [SerializeField] private DialogueData _test;

}
