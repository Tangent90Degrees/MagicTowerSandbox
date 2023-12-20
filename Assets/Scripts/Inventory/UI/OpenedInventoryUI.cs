using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenedInventoryUI : InventoryUI
{
    
    protected override void Awake()
    {
        base.Awake();

        InventoryManager.OnInventoryOpened += OpenInventoryUI;
        InventoryManager.OnInventoryClosed += CloseInventoryUI;
    }

    private void OnDestroy()
    {
        InventoryManager.OnInventoryOpened -= OpenInventoryUI;
        InventoryManager.OnInventoryClosed -= CloseInventoryUI;
    }

    private void Start()
    {
        Inventory = null;
    }


    private void OpenInventoryUI(Inventory inventory)
    {
        Inventory = inventory;
    }

    private void CloseInventoryUI(Inventory inventory)
    {
        Inventory = null;
    }

}
