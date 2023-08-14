using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// An option bar in the selector bar of dialogue UI.
/// </summary>
public class DialogueOptionUI : UITextSlot
{

    /// <summary>
    /// The option this UI bar is displaying.
    /// Updates UI bar when being set.
    /// </summary>
    public DialogueOption Option
    {
        get => _option;
        set
        {
            _option = value;
            if (Option == null)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Text = Option.Content;
                gameObject.SetActive(true);
            }
        }
    }
    
    
    private DialogueOption _option;
    
}
