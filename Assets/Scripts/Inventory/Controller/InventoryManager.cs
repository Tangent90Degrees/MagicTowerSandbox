using System;

public class InventoryManager : Singleton<InventoryManager>
{

    public static event Action<Inventory> OnInventoryOpened;
    public static event Action<Inventory> OnInventoryClosed;

    public static Inventory OpenedInventory
    {
        get => _openedInventory;
        set
        {
            if (OpenedInventory) OnInventoryClosed?.Invoke(OpenedInventory);
            _openedInventory = value;
            if (OpenedInventory) OnInventoryOpened?.Invoke(OpenedInventory);
        }
    }
   
    public static ItemData CurrentUsingItem { get; set; }
    

    /// <summary>
    /// Adds the specified item to the specified inventory.
    /// Invokes OnInventoryUpdates event.
    /// </summary>
    /// <returns>If item is successfully added to inventory.</returns>
    public static bool AddItemToInventory(Item item, Inventory inventory)
    {
        if (!inventory.Add(item)) return false;
        Destroy(item.gameObject);
        return true;
    }

    /// <summary>
    /// Removes the specified item from the specified inventory.
    /// Invokes OnInventoryUpdates event.
    /// </summary>
    /// <returns>If item is successfully removed from inventory.</returns>
    public static bool RemoveItemFromInventory(ItemData item, Inventory inventory)
    {
        return inventory.Remove(item);
    }


    public static Inventory PlayerInventory => GameManager.Player.Inventory;


    private static Inventory _openedInventory;
    
}