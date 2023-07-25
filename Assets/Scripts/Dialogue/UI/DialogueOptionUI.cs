using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// An option bar in the selector bar of dialogue UI.
/// </summary>
public class DialogueOptionUI : MonoBehaviour
{

    /// <summary>
    /// The option this UI bar is displaying.
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
                _content.text = Option.Content;
                gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// The sprite of this UI bar.
    /// </summary>
    public Sprite Sprite
    {
        set => _optionImage.sprite = value;
    }
    
    
    private void Awake()
    {
        _optionImage = GetComponent<Image>();
        _content = GetComponentInChildren<Text>();
    }
    

    private Text _content;
    private Image _optionImage;
    private DialogueOption _option;
    
}
