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
        _spriteRenderer.material = _selectedMaterial;
    }

    public override void OnUnselected()
    {
        _spriteRenderer.material = _defaultMaterial;
    }

    #endregion


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultMaterial = _spriteRenderer.material;
    }
    

    #region On Inspector

    [SerializeField] private ItemData _data;
    [SerializeField] private Material _selectedMaterial;

    #endregion


    private SpriteRenderer _spriteRenderer;
    private Material _defaultMaterial;

}
