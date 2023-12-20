using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    /// <summary>
    /// The inventory data this inventory UI is displaying.
    /// Automatically update UI or data when set.
    /// </summary>
    public Inventory Inventory
    {
        get => _inventory;
        set
        {
            if (Inventory)
            {
                Inventory.OnInventoryUpdate -= UpdateUIFromData;
                UpdateDataFromUI();
            }

            _inventory = value;

            if (Inventory)
            {
                UpdateUIFromData();
                CloseMessage();
                gameObject.SetActive(true);
                Inventory.OnInventoryUpdate += UpdateUIFromData;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }


    #region UI Slots

    public List<UIItemSlot> Slots => _slots;

    public List<ItemStack> Items => Inventory?.Items;
    

    /// <summary>
    /// Updates Inventory UI from data.
    /// </summary>
    private void UpdateUIFromData()
    {
        Dictionary<ItemStack, bool> itemStackIsDisplayed = new();
        Items.ForEach(i => itemStackIsDisplayed.Add(i, false));

        foreach (var slot in Slots)
        {
            if (Items.Contains(slot.ItemStack))
            {
                itemStackIsDisplayed[slot.ItemStack] = true;
            }
            else
            {
                slot.ItemStack = null;
            }
        }

        foreach (var stackIsDisplayed in itemStackIsDisplayed)
        {
            if (!stackIsDisplayed.Value)
            {
                Slots.Find(i => i.ItemStack == null).ItemStack = stackIsDisplayed.Key;
            }
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

    #endregion


    #region UI Message Bar

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

    #endregion


    protected virtual void Awake()
    {
        _slots = new List<UIItemSlot>(_slotsParent.GetComponentsInChildren<UIItemSlot>());
    }


    #region On Inspector

    [Header("UI Components")]
    [SerializeField] private Transform _slotsParent;
    [SerializeField] private UIMessageBar _messageBar;

    #endregion


    private Inventory _inventory;
    private List<UIItemSlot> _slots;

}
