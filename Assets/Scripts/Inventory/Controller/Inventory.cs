using System.Collections;
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

    public ItemStack Add(ItemData item) => Data.Add(item);

    [SerializeField] private InventoryData _data;

}
