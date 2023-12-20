using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A chest that stores items.
/// </summary>
[RequireComponent(typeof(SpriteRenderer), typeof(Inventory))]
public class Chest : Interaction
{

    /// <summary>
    /// The ItemData of this Item.
    /// </summary>
    public Inventory Inventory => _inventory;
    

    #region Interaction

    /// <summary>
    /// Collects this item.
    /// </summary>
    public override void Interact()
    {
        InventoryManager.OpenedInventory = InventoryManager.OpenedInventory == Inventory ? null : Inventory;
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
        _inventory = GetComponent<Inventory>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultMaterial = _spriteRenderer.material;
    }
    

    #region On Inspector

    [SerializeField] private Material _selectedMaterial;

    #endregion

    private Inventory _inventory;
    private SpriteRenderer _spriteRenderer;
    private Material _defaultMaterial;

}
