using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{

    public ItemStack Stack
    {
        get => _stack;
        set
        {
            _stack = value;
            UpdatesSlotUI();
        }
    }

    
    public Sprite SlotSprite
    {
        get => _slotImage.sprite;
        set => _slotImage.sprite = value;
    }
    
    private void Awake()
    {
        _slotImage = GetComponent<Image>();
    }

    private void UpdatesSlotUI()
    {
        if (Stack == null)
        {
            _itemSprite.gameObject.SetActive(false);
            _number.gameObject.SetActive(false);
            return;
        }
        
        _itemSprite.gameObject.SetActive(true);
        _number.gameObject.SetActive(true);
        
        _itemSprite.sprite = Stack.Item.Icon;
        _number.text = Stack.Number.ToString();
    }


    [SerializeField] private Image _itemSprite;
    [SerializeField] private Text _number;

    private Image _slotImage;
    private ItemStack _stack;

}
