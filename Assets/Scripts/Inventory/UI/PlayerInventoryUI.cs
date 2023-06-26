using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{
    
    private void Awake()
    {
        _slots = new List<ItemSlotUI>(GetComponentsInChildren<ItemSlotUI>());
    }

    private void OnEnable()
    {
        InventoryManager.OnInventoryUpdates += UpdatesInventoryUI;
    }

    private void OnDisable()
    {
        InventoryManager.OnInventoryUpdates -= UpdatesInventoryUI;
    }

    private void Start()
    {
        UpdatesInventoryUI(Player.Inventory);
    }


    private void UpdatesInventoryUI(Inventory inventory)
    {
        if (inventory != Player.Inventory)
        {
            return;
        }
        
        // Close all item slots.
        _slots.ForEach(i => i.UpdatesSlotUI(null));

        for (var i = 0; i < inventory.Items.Count; i++)
        {
            _slots[i].UpdatesSlotUI(inventory.Items[i]);
        }
    }

    private List<ItemSlotUI> _slots;
    
}
