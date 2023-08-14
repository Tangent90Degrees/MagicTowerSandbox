using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// An unclickable text label.
/// </summary>
[RequireComponent(typeof(RectTransform))]
public class UIMessageBar : MonoBehaviour
{

    public void Log(string text)
    {
        _messageText.text = text;

        // Resize the message bar.
        _transform.sizeDelta = new Vector2(_messageText.preferredWidth + _horizontalPadding, _height);
    }
    

    private void Awake()
    {
        _messageText = GetComponentInChildren<Text>();
        _transform = GetComponent<RectTransform>();
    }


    #region On Inspector

    [Header("Size")]

    [SerializeField] private float _height;
    [SerializeField] private float _horizontalPadding;
    
    #endregion


    private Text _messageText;
    private RectTransform _transform;

}
