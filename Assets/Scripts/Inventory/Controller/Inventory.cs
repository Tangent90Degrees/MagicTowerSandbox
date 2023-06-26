using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An Inventory behaviour.
/// </summary>
public class Inventory : MonoBehaviour
{

    /// <summary>
    /// The InventoryData of the Inventory.
    /// </summary>
    public InventoryData Data => _data;

    public List<ItemStack> Items => Data.Items;


    /// <summary>
    /// Adds the specified item to this inventory.
    /// Should use InventoryManager.AddItemToInventory when collecting an item.
    /// </summary>
    /// <param name="item">The item to add.</param>
    /// <returns>If the item is successfully added to this inventory.</returns>
    public bool Add(Item item) => Data.Add(item.Data, out _);
    
    /// <summary>
    /// Removes the specified item from this inventory.
    /// Should use InventoryManager.RemoveItemFromInventory when removing an item.
    /// </summary>
    /// <param name="item">The data of the item to remove.</param>
    /// <returns>If the item is successfully removed from this inventory.</returns>
    public bool Remove(ItemData item) => Data.Remove(item, out _);

    /// <summary>
    /// If this inventory contains the specified item.
    /// </summary>
    public bool Contains(Item item) => Data.Contains(item.Data);
    

    [SerializeField] private InventoryData _data;

}
