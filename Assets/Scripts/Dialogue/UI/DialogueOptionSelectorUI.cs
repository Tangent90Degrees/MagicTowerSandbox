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
        DialogueManager.OnTurnLoaded += OptionsUILoading;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            SelectedIndex += (int)Input.GetAxisRaw("Horizontal");
        }
    }


    private void OptionsUILoading(DialogueTurn _)
    {
        if (DialogueManager.IsSelectingOption)
        {
            LoadOptionsUI();
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void LoadOptionsUI()
    {
        // Destroy all option UI.
        _optionUIs.ForEach(i => i.Option = null);

        for (var i = 0; i < Options.Count; i++)
        {
            _optionUIs[i].Option = Options[i];
        }
    }

    /// <summary>
    /// Selects the option of the index.
    /// </summary>
    private void SelectOption(int index)
    {
        // Unselect all options.
        _optionUIs.ForEach(i => i.Sprite = _optionSprite);
        
        // Select the slot of index.
        _optionUIs[index].Sprite = _optionSelectedSprite;
        DialogueManager.SelectedOption = _optionUIs[index].Option;
    }
    

    #region On Inspector

    [Header("Options")]
    [SerializeField] private Sprite _optionSprite;
    [SerializeField] private Sprite _optionSelectedSprite;

    #endregion
    
    
    private List<DialogueOptionUI> _optionUIs;
    private int _selectedIndex;
    
}
