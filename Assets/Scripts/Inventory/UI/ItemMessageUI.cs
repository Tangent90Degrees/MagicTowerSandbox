using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The message bar displays information of the selected item.
/// </summary>
public class ItemMessageUI : MonoBehaviour
{

    /// <summary>
    /// The height of the message bar.
    /// </summary>
    private static float Height => 8;
    
    /// <summary>
    /// The width of space between message bar and the text.
    /// </summary>
    private static float HorizontalPadding => 4;
    

    /// <summary>
    /// Displays information of the specified item stack.
    /// </summary>
    /// <param name="stack"></param>
    public void Log(ItemStack stack)
    {
        // Close message bar if stack is empty.
        if (stack == null)
        {
            gameObject.SetActive(false);
            return;
        }
        
        gameObject.SetActive(true);
        var message = "<b><color=orange>" + stack.Item.Name + "</color></b>";
        var number = stack.Number == 1 ? string.Empty : " - " + stack.Number;
        _messageText.text = message + number;

        // Resize the message bar.
        _transform.sizeDelta = new Vector2(_messageText.preferredWidth + HorizontalPadding, Height);
    }
    

    private void Awake()
    {
        _messageText = GetComponentInChildren<Text>();
        _transform = GetComponent<RectTransform>();
    }


    private Text _messageText;

    private RectTransform _transform;
    
}
