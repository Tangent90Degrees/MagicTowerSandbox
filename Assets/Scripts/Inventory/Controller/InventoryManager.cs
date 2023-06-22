using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{

    /// <summary>
    /// This event invokes when items of an inventory are changed.
    /// </summary>
    public static event Action<InventoryData> OnInventoryUpdates;

    public static void InventoryUpdates(InventoryData inventory) => OnInventoryUpdates?.Invoke(inventory);


    public static Inventory PlayerInventory => Player.Inventory;
    
}