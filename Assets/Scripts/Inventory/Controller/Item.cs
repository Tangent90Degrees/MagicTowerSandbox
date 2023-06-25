using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A collective item in scene.
/// Destroy itself after collected.
/// </summary>
public class Item : MonoBehaviour, IInteractive
{

    /// <summary>
    /// The ItemData of this Item.
    /// </summary>
    public ItemData Data => _data;
    

    private void Awake()
    {
        _spriteRanderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        InteractManager.OnInteractionSlected += SetSelectedImage;
        InteractManager.OnInteractionUnslected += SetNotSelectedImage;
    }

    private void OnDestroy()
    {
        InteractManager.OnInteractionSlected -= SetSelectedImage;
        InteractManager.OnInteractionUnslected -= SetNotSelectedImage;
    }


    /// <summary>
    /// Collects this item.
    /// </summary>
    public void Interact()
    {
        if (InventoryManager.PlayerInventory.Add(Data, out _))
        {
            Destroy(gameObject);
        }
    }


    private void SetSelectedImage(IInteractive interaction)
    {
        if (interaction == this as IInteractive)
        {
            _spriteRanderer.sprite = _selectedSprite;
        }
    }


    private void SetNotSelectedImage(IInteractive interaction)
    {
        if (interaction == this as IInteractive)
        {
            _spriteRanderer.sprite = _sprite;
        }
    }



    #region On Inspector

    [SerializeField] private ItemData _data;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Sprite _selectedSprite;

    #endregion


    private SpriteRenderer _spriteRanderer;

}
