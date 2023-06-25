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

    public bool Add(ItemData item, out ItemStack stack) => Data.Add(item, out stack);

    [SerializeField] private InventoryData _data;

}
