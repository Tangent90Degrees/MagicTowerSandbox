using UnityEngine;

/// <summary>
/// A collective item in scene.
/// Destroy itself after collected.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class Item : Interaction
{

    /// <summary>
    /// The ItemData of this Item.
    /// </summary>
    public ItemData Data => _data;
    

    #region Interaction

    /// <summary>
    /// Collects this item.
    /// </summary>
    public override void Interact()
    {
        InventoryManager.AddItemToInventory(this, InventoryManager.PlayerInventory);
    }

    public override void OnSelected()
    {
        _spriteRenderer.sprite = _selectedSprite;
    }

    public override void OnUnselected()
    {
        _spriteRenderer.sprite = _sprite;
    }

    #endregion


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    

    #region On Inspector

    [SerializeField] private ItemData _data;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Sprite _selectedSprite;

    #endregion


    private SpriteRenderer _spriteRenderer;

}
