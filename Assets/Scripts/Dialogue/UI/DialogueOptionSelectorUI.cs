using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The selector bar of dialogue UI.
/// </summary>
public class DialogueOptionSelectorUI : MonoBehaviour
{
    
    /// <summary>
    /// The list of all options of current dialogue.
    /// </summary>
    private static List<DialogueOption> Options => DialogueManager.Dialogue.Options;

    /// <summary>
    /// If current turn is the last turn of the dialogue which does not end.
    /// </summary>
    private static bool IsSelectingOption => DialogueManager.IsSelectingOption;

    /// <summary>
    /// The selected option of current dialogue.
    /// </summary>
    private static DialogueOption SelectedOption
    {
        get => DialogueManager.SelectedOption;
        set => DialogueManager.SelectedOption = value;
    }

    /// <summary>
    /// The index of selected option of Options.
    /// Selects the option of specified index when being set.
    /// </summary>
    private int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            _selectedIndex = Mathf.Clamp(value, 0, Options.Count - 1);
            SelectOption(SelectedIndex);
        }
    }

    
    private void Awake()
    {
        _optionUIs = new List<DialogueOptionUI>(GetComponentsInChildren<DialogueOptionUI>());
        DialogueManager.OnTurnLoaded += LoadOptionsUI;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            SelectedIndex += (int)Input.GetAxisRaw("Horizontal");
        }
    }


    /// <summary>
    /// This method is called when the turn is set.
    /// </summary>
    private void LoadOptionsUI(DialogueTurn _)
    {
        if (IsSelectingOption)
        {
            // Disable all option UI.
            _optionUIs.ForEach(i => i.Option = null);

            // Enable option UIs to fit options in the model.
            for (var i = 0; i < Options.Count; i++)
            {
                _optionUIs[i].Option = Options[i];
            }
            SelectedIndex = 0;

            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Selects the option of the index.
    /// This method is called when SelectedIndex is set.
    /// </summary>
    private void SelectOption(int index)
    {
        // Unselect all options.
        _optionUIs.ForEach(i => i.Sprite = _optionSprite);
        
        // Select the slot of index.
        _optionUIs[index].Sprite = _optionSelectedSprite;
        SelectedOption = _optionUIs[index].Option;
    }
    

    #region On Inspector

    [Header("Options")]
    [SerializeField] private Sprite _optionSprite;
    [SerializeField] private Sprite _optionSelectedSprite;

    #endregion
    
    
    private List<DialogueOptionUI> _optionUIs;
    private int _selectedIndex;
    
}
