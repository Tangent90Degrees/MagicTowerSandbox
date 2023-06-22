using System.Collections;
using System.Collections.Generic;
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
    public bool IsFull => Items.Count == size;


    /// <summary>
    /// Adds the specified Item in the Inventory.
    /// </summary>
    public ItemStack Add(ItemData item)
    {
        if (IsFull)
        {
            Debug.Log("Inventory is full!");
            return null;
        }
        ItemStack stack = GetItemStack(item);
        if (stack == null || stack.IsFull)
        {
            ItemStack res = new(item);
            Items.Add(res);
            return res;
        }
        else
        {
            stack.Number++;
            return stack;
        }
    }

    /// <summary>
    /// Removes the specified Item in the Inventory.
    /// </summary>
    public ItemStack Remove(ItemData item)
    {
        ItemStack stack = GetItemStack(item);
        if (stack == null)
        {
            Debug.Log("Inventory does not contain this item!");
            return null;
        }
        else
        {
            stack.Number--;
            if (stack.IsEmpty)
            {
                Items.Remove(stack);
                return null;
            }
            return stack;
        }
    }

    /// <summary>
    /// If the specified Item is in the Inventory
    /// </summary>
    public bool Contains(ItemData item)
    {
        foreach (ItemStack stack in Items)
        {
            if (stack.Item == item)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Finds the specified Item the Inventory.
    /// </summary>
    public ItemStack GetItemStack(ItemData item)
    {
        ItemStack res = null;
        foreach (ItemStack stack in Items)
        {
            if (stack.Item == item)
            {
                if (res == null || res.Number > stack.Number)
                {
                    res = stack;
                }
            }
        }
        return res;
    }


    #region On Inspector

    [SerializeField] private int size;
    [SerializeField] private List<ItemStack> _items;

    #endregion
    
}
