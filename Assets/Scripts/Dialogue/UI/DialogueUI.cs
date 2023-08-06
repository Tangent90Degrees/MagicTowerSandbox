using System.Collections;
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


    private void Awake()
    {
        _text = GetComponentInChildren<Text>();

        DialogueManager.OnDialogueStarting += _ => gameObject.SetActive(true);
        DialogueManager.OnTurnLoaded += PrintContentOfTurn;
        DialogueManager.OnDialogueEnding += _ => gameObject.SetActive(false);
    }

    private void Update()
    {
        if (DialogueManager.IsDuringDialogue && Input.GetButtonDown("Interact"))
        {
            Push();
        }
    }


    /// <summary>
    /// Pushes to next step of the dialogue process.
    /// </summary>
    private void Push()
    {
        if (_isPrintingText)
        {
            // Finishes printing text.
            StopCoroutine(_printingCoroutine);
            _isPrintingText = false;
            _text.text = Turn.Content;
        }
        else if (DialogueManager.IsSelectingOption)
        {
            // Starts following dialogue.
            DialogueManager.Dialogue = DialogueManager.SelectedOption.NextDialogue;
        }
        else if (DialogueManager.Ends)
        {
            // Close dialogue UI bar.
            DialogueManager.Dialogue = null;
        }
        else
        {
            // Next turn.
            DialogueManager.TurnIndex++;
        }
    }


    /// <summary>
    /// This method is called after the turn changes.
    /// </summary>
    private void PrintContentOfTurn(DialogueTurn turn)
    {
        if (!gameObject.activeSelf) return;
        _printingCoroutine = PrintTextCoroutine(turn == null ? string.Empty : turn.Content);
        StartCoroutine(_printingCoroutine);
    }


    /// <summary>
    /// The coroutine of printing text character by character.
    /// </summary>
    private IEnumerator PrintTextCoroutine(string text)
    {
        // Clears all text.
        _isPrintingText = true;
        _text.text = string.Empty;

        // Prints text character by character.
        foreach (var character in text)
        {
            _text.text += character;
            yield return new WaitForSeconds(_textPrintingDuration);
        }

        _isPrintingText = false;
    }


    #region On Inspector

    [SerializeField] private float _textPrintingDuration;

    #endregion
    

    private Text _text;
    private IEnumerator _printingCoroutine;
    private bool _isPrintingText;

}
