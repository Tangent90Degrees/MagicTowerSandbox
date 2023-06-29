using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The parents of all item slots.
/// </summary>
public class PlayerInventoryUI : MonoBehaviour
{
    
    /// <summary>
    /// The index of current selected item.
    /// </summary>
    private int SelectedSlotIndex
    {
        get => _selectedSlotIndex;
        set
        {
            _selectedSlotIndex = (value + _slots.Count) % _slots.Count;
            SelectSlot(SelectedSlotIndex);
        }
    }
    
    
    private void Awake()
    {
        _slots = new List<ItemSlotUI>(GetComponentsInChildren<ItemSlotUI>());
    }

    private void OnEnable()
    {
        InventoryManager.OnInventoryUpdates += UpdateInventoryUI;
    }

    private void OnDisable()
    {
        InventoryManager.OnInventoryUpdates -= UpdateInventoryUI;
    }

    private void Start()
    {
        UpdateInventoryUI(Player.Inventory);
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SelectedSlotIndex++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            SelectedSlotIndex--;
        }
    }


    /// <summary>
    /// Updates items displayed on UI when player's inventory changes.
    /// </summary>
    private void UpdateInventoryUI(Inventory inventory)
    {
        // Do nothing if inventory is not player's.
        if (inventory != Player.Inventory) return;

        // Close all item slots.
        _slots.ForEach(i => i.Stack = null);
        
        // Display items in player's inventory.
        for (var i = 0; i < inventory.Items.Count; i++)
        {
            _slots[i].Stack = inventory.Items[i];
        }
        
        SelectSlot(SelectedSlotIndex);
    }


    /// <summary>
    /// Selects the slot of the index.
    /// </summary>
    private void SelectSlot(int index)
    {
        // Unselect all slots.
        _slots.ForEach(i => i.SlotSprite = _slotSprite);
        
        // Select the slot of index.
        _slots[index].SlotSprite = _selectedSlotSprite;
        InventoryManager.CurrentUsingItem = 
            _slots[index].Stack == null ? null : _slots[index].Stack.Item;

        _message.Log(_slots[index].Stack);
    }


    #region On Inspector

    [Header("Item Slots")]
    [SerializeField] private Sprite _slotSprite;
    [SerializeField] private Sprite _selectedSlotSprite;

    [Header("Message")]
    [SerializeField] private ItemMessageUI _message;

    #endregion
    

    private List<ItemSlotUI> _slots;
    private int _selectedSlotIndex;

}
