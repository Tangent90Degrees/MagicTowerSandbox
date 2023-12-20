using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryUI : InventoryUI
{
    
    private void Start()
    {
        Inventory = InventoryManager.PlayerInventory;
    }

}
