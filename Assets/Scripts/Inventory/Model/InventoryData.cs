using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// An Inventory contains some Items.
/// </summary>
[CreateAssetMenu(menuName = "Inventory/Inventory")]
public class InventoryData : ScriptableObject
{

    /// <summary>
    /// The list of all ItemStack in the Inventory.
    /// </summary>
    public List<ItemStack> Items => _items;
    
    /// <summary>
    /// If the Inventory can not add new ItemStacks.
    /// </summary>
    public bool IsFull => Items.Count == _size;
    

    /// <summary>
    /// Adds the specified Item in the Inventory.
    /// </summary>
    /// <param name="item">The data of Item to add.</param>
    /// <param name="stack">The ItemStack in this Inventory.</param>
    /// <returns>If the Item is successfully added to this Inventory.</returns>
    public bool Add(ItemData item, out ItemStack stack)
    {
        // Fail to add item if inventory is full.
        if (IsFull)
        {
            stack = null;
            return false;
        }
        
        // Finds the min ItemStack of item.
        var stackInInventory = GetItemStack(item);
        
        // Add item in a new stack if stack is full or does not contain item.
        if (stackInInventory == null || stackInInventory.IsFull)
        {
            stack = new ItemStack(item);
            Items.Add(stack);
            return true;
        }

        // Add item in found stack.
        stackInInventory.Number++;
        stack = stackInInventory;
        return true;
    }
    
    /// <summary>
    /// Removes the specified Item in the Inventory.
    /// </summary>
    /// <param name="item">The data of Item to remove.</param>
    /// <param name="stack">The ItemStack in this Inventory.</param>
    /// <returns>If the Item is successfully removed from this Inventory.</returns>
    public bool Remove(ItemData item, out ItemStack stack)
    {
        // Finds the min ItemStack of item.
        var stackInInventory = GetItemStack(item);
        
        // Fail to remove item if does not contain item.
        if (stackInInventory == null)
        {
            stack = null;
            return false;
        }

        // Remove item in found stack.
        stackInInventory.Number--;
        stack = stackInInventory;
        if (stackInInventory.IsEmpty) Items.Remove(stackInInventory);
        return true;
    }
    
    /// <summary>
    /// If the specified Item is in the Inventory
    /// </summary>
    public bool Contains(ItemData item)
    {
        return Items.Any(stack => stack.Item == item);
    }
    

    /// <summary>
    /// Finds the stack with the min number of items for the specified item.
    /// </summary>
    private ItemStack GetItemStack(ItemData item)
    {
        ItemStack res = null;
        
        foreach (var stack in Items)
        {
            if (stack.Item == item && (res == null || res.Number > stack.Number))
            {
                res = stack;
            }
        }
        
        return res;
    }


    #region On Inspector

    [SerializeField] private int _size;
    [SerializeField] private List<ItemStack> _items;

    #endregion
    
}
