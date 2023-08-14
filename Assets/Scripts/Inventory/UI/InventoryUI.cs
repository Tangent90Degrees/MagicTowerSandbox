using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public List<UIItemSlot> Slots => _slots;

    public List<ItemStack> Items => _inventory?.Items;


    public void UpdateInventoryUI(Inventory inventory)
    {
        if (inventory.Data == _inventory)
        {
            UpdateUIFromData();
        }
    }

    private void UpdateUIFromData()
    {
        Slots.ForEach(i => i.ItemStack = null);
        for (var i = 0; i < Items.Count; i++)
        {
            Slots[i].ItemStack = Items[i];
        }
    }

    private void UpdateDataFromUI()
    {
        Items.Clear();
        foreach (var slot in Slots.Where(i => i.ItemStack != null))
        {
            Items.Add(slot.ItemStack);
        }
    }

    /// <summary>
    /// Displays information of the specified item stack.
    /// </summary>
    public void LogMessage(UIItemSlot slot)
    {
        if (slot.ItemStack == null)
        {
            CloseMessage();
            return;
        }

        _messageBar.gameObject.SetActive(true);
        var message = "<b><color=orange>" + slot.ItemStack.Item.Name + "</color></b>";
        var number = slot.ItemStack.Number == 1 ? string.Empty : " - " + slot.ItemStack.Number;
        _messageBar.Log(message + number);
    }

    public void CloseMessage()
    {
        _messageBar.gameObject.SetActive(false);
    }


    private void Awake()
    {
        _slots = new List<UIItemSlot>(_slotsParent.GetComponentsInChildren<UIItemSlot>());
    }

    private void OnEnable()
    {
        InventoryManager.OnInventoryUpdates += UpdateInventoryUI;
        UpdateUIFromData();
        CloseMessage();
    }

    private void OnDisable()
    {
        InventoryManager.OnInventoryUpdates -= UpdateInventoryUI;
    }


    #region On Inspector

    [Header("Inventory Settings")]

    [SerializeField] private InventoryData _inventory;

    [Header("UI Components")]

    [SerializeField] private Transform _slotsParent;
    [SerializeField] private UIMessageBar _messageBar;

    #endregion


    private List<UIItemSlot> _slots;

}
