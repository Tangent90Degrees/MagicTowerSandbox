using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A serialized item/number pair that can be set or retrieved.
/// </summary>
[System.Serializable]
public class ItemStack
{
    /// <summary>
    /// Initializes a new instance of the Pair record with the specified key and value.
    /// </summary>
    public ItemStack(ItemData item, int number)
    {
        (_item, Number) = (item, number);
    }

    /// <summary>
    /// Initializes a new instance of the Pair record with the specified key.
    /// </summary>
    public ItemStack(ItemData item)
    {
        (_item, Number) = (item, 1);
    }

    /// <summary>
    /// The item of the ItemStack.
    /// </summary>
    public ItemData Item => _item;

    /// <summary>
    /// The number of the item in the ItemStack.
    /// </summary>
    public int Number
    {
        get => _number;
        set => _number = Mathf.Clamp(value, 0, Item.MaxStackTimes);
    }

    /// <summary>
    /// If number equals 0.
    /// </summary>
    public bool IsEmpty => Number == 0;

    /// <summary>
    /// If number equals max stack times.
    /// </summary>
    public bool IsFull => Number == Item.MaxStackTimes;


    #region On Inspector

    [SerializeField] private ItemData _item;
    [SerializeField] private int _number;

    #endregion

}
