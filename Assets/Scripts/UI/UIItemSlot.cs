using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A UIBlock that displays an item.
/// </summary>
public class UIItemSlot : UIBlock
{

    /// <summary>
    /// The item stack this slot holds.
    /// </summary>
    public ItemStack ItemStack
    {
        get => _itemStack;
        set
        {
            _itemStack = value;
            UpdateSlotUI(ItemStack);
        }

    }


    /// <summary>
    /// Changes the sprite of the item image.
    /// This method is called when ItemStack is set.
    /// </summary>
    private void UpdateSlotUI(ItemStack itemStack)
    {
        // Close item image if the stack is empty.
        if (itemStack == null)
        {
            _itemImage.gameObject.SetActive(false);
            return;
        }
        
        // Enable item image and set its sprite to the item icon.
        _itemImage.gameObject.SetActive(true);
        _itemImage.sprite = itemStack.Item.Icon;
    }

    
    #region On Inspector

    [Header("Item Slot Components")]

    [SerializeField] private Image _itemImage;

    #endregion


    private ItemStack _itemStack;

}
