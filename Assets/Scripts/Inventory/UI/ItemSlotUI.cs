using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{

    public void UpdatesSlotUI(ItemStack stack)
    {
        if (stack == null)
        {
            _itemSprite.gameObject.SetActive(false);
            _number.gameObject.SetActive(false);
            return;
        }
        
        _itemSprite.gameObject.SetActive(true);
        _number.gameObject.SetActive(true);
        
        _itemSprite.sprite = stack.Item.Icon;
        _number.text = stack.Number.ToString();
    }


    [SerializeField] private Image _itemSprite;
    [SerializeField] private Text _number;
    
}
