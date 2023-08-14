using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The dialogue UI bar for printing dialogue contents.
/// </summary>
public class DialogueUI : MonoBehaviour
{

    /// <summary>
    /// The current turn of the dialogue.
    /// </summary>
    public static DialogueTurn Turn => DialogueManager.Turn;
    

    public void StartDialogueOfOption(DialogueOptionUI option)
    {
        DialogueManager.Dialogue = option.Option.NextDialogue;
    }

    /// <summary>
    /// Pushes to next step of the dialogue process.
    /// </summary>
    public void Push()
    {
        if (_contentPrinter.IsPrinting)
        {
            // Finishes printing text.
            _contentPrinter.StopPrinting(Turn.Content);
        }
        else if (DialogueManager.Ends)
        {
            // Close dialogue UI bar.
            DialogueManager.Dialogue = null;
        }
        else if (!DialogueManager.IsSelectingOption)
        {
            // Next turn.
            DialogueManager.TurnIndex++;
        }
        
    }


    private void Awake()
    {
        _optionUIs = new List<DialogueOptionUI>(GetComponentsInChildren<DialogueOptionUI>());

        DialogueManager.OnDialogueStarting += StartDialogueUI;
        DialogueManager.OnTurnLoaded += UpdateDialogueUI;
        DialogueManager.OnDialogueEnding += EndDialogueUI;
    }

    private void Update()
    {
        if (DialogueManager.IsDuringDialogue && Input.GetButtonDown("Interact"))
        {
            Push();
        }
    }

    private void OnDistroy()
    {
        DialogueManager.OnDialogueStarting -= StartDialogueUI;
        DialogueManager.OnTurnLoaded -= UpdateDialogueUI;
        DialogueManager.OnDialogueEnding -= EndDialogueUI;
    }


    private void StartDialogueUI(DialogueData dialogue)
    {
        _contentPrinter.gameObject.SetActive(true);
        LoadOptions(DialogueManager.Dialogue);
    }

    private void EndDialogueUI(DialogueData dialogue)
    {
        _contentPrinter.gameObject.SetActive(false);
        _optionsParent.gameObject.SetActive(false);
    }

    private void UpdateDialogueUI(DialogueTurn turn)
    {
        PrintContentOfTurn(turn);
        _optionsParent.gameObject.SetActive(DialogueManager.IsSelectingOption);
    }


    /// <summary>
    /// This method is called after the turn changes.
    /// </summary>
    private void PrintContentOfTurn(DialogueTurn turn)
    {
        if (!gameObject.activeSelf) return;
        var content = turn == null ? string.Empty : turn.Content;
        _contentPrinter.Print(content);
    }

    private void LoadOptions(DialogueData dialogue)
    {
        _optionUIs.ForEach(i => i.Option = null);
        for (int i = 0; i < dialogue.Options.Count; i++)
        {
            _optionUIs[i].Option = dialogue.Options[i];
        }
    }


    #region On Inspector

    [Header("Components")]

    [SerializeField] private UITextPrinter _contentPrinter;
    [SerializeField] private Transform _optionsParent;

    #endregion


    private List<DialogueOptionUI> _optionUIs;

}
