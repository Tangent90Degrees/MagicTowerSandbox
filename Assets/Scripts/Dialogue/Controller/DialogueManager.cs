using System;
using UnityEngine;

/// <summary>
/// The manager of dialogue processing.
/// </summary>
public class DialogueManager : Singleton<DialogueManager>
{

    /// <summary>
    /// This event invokes after a new dialogue starts.
    /// </summary>
    public static event Action<DialogueData> OnDialogueStarting;

    /// <summary>
    /// This event invokes when turn is set.
    /// </summary>
    public static event Action<DialogueTurn> OnTurnLoaded;

    /// <summary>
    /// This event invokes before the dialogue ends.
    /// </summary>
    public static event Action<DialogueData> OnDialogueEnding;


    /// <summary>
    /// The current dialogue is displaying.
    /// Set to null to end current dialogue.
    /// </summary>
    public static DialogueData Dialogue
    {
        get => _dialogue;
        set
        {
            if (!value) OnDialogueEnding?.Invoke(Dialogue);
            _dialogue = value;
            TurnIndex = 0;
            if (IsDuringDialogue) OnDialogueStarting?.Invoke(Dialogue);
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


    /// <summary>
    /// The max distance between the player and the other speaker.
    /// </summary>
    public static float MaxDialogueDistance => Instance._maxDialogueDistance;


    /// <summary>
    /// If current turn is the last turn of the dialogue.
    /// </summary>
    public static bool IsLastTurn => IsDuringDialogue && TurnIndex == Dialogue.Turns.Count - 1;

    /// <summary>
    /// If current turn is the last turn of the dialogue which does not end.
    /// </summary>
    public static bool IsSelectingOption => IsLastTurn && !Dialogue.Ends;

    /// <summary>
    /// If current turn is the last turn of the dialogue which ends.
    /// </summary>
    public static bool Ends => IsLastTurn && Dialogue.Ends;


    /// <summary>
    /// If is during a dialogue.
    /// </summary>
    public static bool IsDuringDialogue => Dialogue;


    /// <summary>
    /// The selected option of current dialogue.
    /// </summary>
    public static DialogueOption SelectedOption { get; set; }
    

    #region On Inspector

    [SerializeField] private float _maxDialogueDistance;

    #endregion


    private static DialogueData _dialogue;
    private static DialogueTurn _turn;
    private static int _turnIndex;

}
