using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
        DialogueManager.OnTurnLoaded += DisplayText;
    }


    private void DisplayText(DialogueTurn turn)
    {
        if (turn == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            StartCoroutine(DisplayTextCoroutine(turn.Content));
        }
    }

    private IEnumerator DisplayTextCoroutine(string text)
    {
        _text.text = string.Empty;
        foreach (var character in text)
        {
            _text.text += character;
            yield return new WaitForSeconds(_textPrintingDuration);
        }
    }


    [SerializeField] private float _textPrintingDuration;
    

    private Text _text;

}
