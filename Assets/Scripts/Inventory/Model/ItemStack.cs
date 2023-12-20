using System;
using UnityEngine;

/// <summary>
/// A serializable item/number pair that can be set or retrieved.
/// </summary>
[Serializable]
public class ItemStack
{
    
    /// <summary>
    /// Initializes a new item stack instance with the specified item and number.
    /// </summary>
    public ItemStack(ItemData item, int number = 1)
    {
        Item = item;
        Number = number;
    }


    /// <summary>
    /// This event invokes when the number of item is changed.
    /// </summary>
    public event Action<int> NumberChanged;


    /// <summary>
    /// The item of this item stack.
    /// </summary>
    public ItemData Item
    {
        get => _item;
        init => _item = value;
    }

    /// <summary>
    /// The number of the item in this item stack.
    /// </summary>
    public int Number
    {
        get => _number;
        set
        {
            _number = Mathf.Clamp(value, 0, Item.MaxStackTimes);
            NumberChanged?.Invoke(Number);
        }
    }


    /// <summary>
    /// If the number equals 0.
    /// </summary>
    public bool IsEmpty => Number == 0;

    /// <summary>
    /// If the number reaches the max stack times.
    /// </summary>
    public bool IsFull => Number == Item.MaxStackTimes;


    #region On Inspector

    [SerializeField] private ItemData _item;
    [SerializeField] private int _number;

    #endregion

}
