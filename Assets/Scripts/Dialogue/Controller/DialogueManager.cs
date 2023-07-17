using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    
    public static DialogueData CurrentDialogue { get; set; }

    public static bool IsDuringDialogue { get; set; }

    public static int CurrentTurnIndex { get; set; }

    public DialogueTurn CurrentTurn => CurrentDialogue.Turns[CurrentTurnIndex];

    public static void StartDialogue(DialogueData dialogue)
    {
        CurrentDialogue = dialogue;
        CurrentTurnIndex = 0;
        IsDuringDialogue = true;
    }
}
