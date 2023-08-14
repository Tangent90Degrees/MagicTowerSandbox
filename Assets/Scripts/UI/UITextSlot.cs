using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextSlot : UIBlock
{

    /// <summary>
    /// The item stack this slot holds.
    /// </summary>
    public string Text { get => _text.text; set => _text.text = value; }

    
    #region On Inspector

    [Header("Text Slot Components")]

    [SerializeField] private Text _text;

    #endregion

}
