using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Implements the effect of printing text character by character.
/// </summary>
public class UITextPrinter : MonoBehaviour
{

    /// <summary>
    /// If this printer is printing text.
    /// </summary>
    public bool IsPrinting { get => _isPrinting; private set => _isPrinting = value; }


    /// <summary>
    /// This method is called after the turn changes.
    /// </summary>
    public void Print(string text)
    {
        if (gameObject.activeInHierarchy)
        {
            _printingCoroutine = PrintCoroutine(text);
            StartCoroutine(_printingCoroutine);
        }
    }

    public void StopPrinting()
    {
        if (IsPrinting)
        {
            StopCoroutine(_printingCoroutine);
            IsPrinting = false;
        }
    }

    public void StopPrinting(string endText)
    {
        if (IsPrinting)
        {
            StopCoroutine(_printingCoroutine);
            IsPrinting = false;
        }
        _text.text = endText;
    }


    /// <summary>
    /// The coroutine of printing text character by character.
    /// </summary>
    private IEnumerator PrintCoroutine(string text)
    {
        _text.text = string.Empty;
        IsPrinting = true;

        // Prints text character by character.
        foreach (var character in text)
        {
            _text.text += character;
            yield return new WaitForSeconds(_textPrintingDuration);
        }

        IsPrinting = false;
    }


    #region On Inspector

    [SerializeField] private Text _text;
    [SerializeField] private float _textPrintingDuration;

    #endregion
    

    private IEnumerator _printingCoroutine;
    private bool _isPrinting;

}
