using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A container of an item in player's inventory displayed on UI.
/// </summary>
public class ItemSlotUI : MonoBehaviour
{

    /// <summary>
    /// The item stack in player's inventory this slot holds.
    /// </summary>
    public ItemStack Stack
    {
        get => _stack;
        set
        {
            _stack = value;
            UpdatesSlotUI();
        }
    }
    
    /// <summary>
    /// The sprite of the slot container.
    /// </summary>
    public Sprite SlotSprite
    {
        get => _slotImage.sprite;
        set => _slotImage.sprite = value;
    }
    
    
    private void Awake()
    {
        _slotImage = GetComponent<Image>();
    }
    

    /// <summary>
    /// Changes the sprite of the item image.
    /// This method is called when the stack is changed.
    /// </summary>
    private void UpdatesSlotUI()
    {
        // Close item image if the stack is empty.
        if (Stack == null)
        {
            _itemImage.gameObject.SetActive(false);
            return;
        }
        
        // Enable item image and set its sprite to the item icon.
        _itemImage.gameObject.SetActive(true);
        _itemImage.sprite = Stack.Item.Icon;
    }


    [SerializeField] private Image _itemImage;
    

    private Image _slotImage;
    private ItemStack _stack;

}
