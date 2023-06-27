using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{

    public int SelectSlotIndex
    {
        get => _selectedSlotIndex;
        set
        {
            _selectedSlotIndex = (value + _slots.Count) % _slots.Count;
            SelectsSlot();
        }
    }
    
    
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

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SelectSlotIndex++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            SelectSlotIndex--;
        }
    }


    private void UpdatesInventoryUI(Inventory inventory)
    {
        if (inventory != Player.Inventory)
        {
            return;
        }
        
        // Close all item slots.
        _slots.ForEach(i => i.Stack = null);

        for (var i = 0; i < inventory.Items.Count; i++)
        {
            _slots[i].Stack = inventory.Items[i];
        }
    }


    private void SelectsSlot()
    {
        _slots.ForEach(i => i.SlotSprite = _slotSprite);
        _slots[SelectSlotIndex].SlotSprite = _selectedSlotSprite;
        InventoryManager.CurrentUsingItem = 
            _slots[SelectSlotIndex].Stack == null ? null : _slots[SelectSlotIndex].Stack.Item;
    }


    #region On Inspector

    [SerializeField] private Sprite _slotSprite;
    [SerializeField] private Sprite _selectedSlotSprite;

    #endregion
    

    private List<ItemSlotUI> _slots;
    private int _selectedSlotIndex;

}
