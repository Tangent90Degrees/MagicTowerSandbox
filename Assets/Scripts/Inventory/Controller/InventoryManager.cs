using System;

public class InventoryManager : Singleton<InventoryManager>
{

    /// <summary>
    /// This event invokes when items of an inventory are changed.
    /// </summary>
    public static event Action<Inventory> OnInventoryUpdates;
    
    
    public static ItemData CurrentUsingItem { get; set; }
    

    /// <summary>
    /// Adds the specified item to the specified inventory.
    /// Invokes OnInventoryUpdates event.
    /// </summary>
    /// <returns>If item is successfully added to inventory.</returns>
    public static bool AddItemToInventory(Item item, Inventory inventory)
    {
        if (!inventory.Add(item)) return false;
        
        OnInventoryUpdates?.Invoke(inventory);
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
        if (!inventory.Remove(item)) return false;

        OnInventoryUpdates?.Invoke(inventory);
        return true;
    }


    public static Inventory PlayerInventory => GameManager.Player.Inventory;
    
}