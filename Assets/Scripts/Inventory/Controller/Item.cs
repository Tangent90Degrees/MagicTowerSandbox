using UnityEngine;

/// <summary>
/// A collective item in scene.
/// Destroy itself after collected.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour, IInteractive
{

    /// <summary>
    /// The ItemData of this Item.
    /// </summary>
    public ItemData Data => _data;
    

    /// <summary>
    /// The max distance between the player and this item that enables collecting.
    /// </summary>
    public float MaxDistance => _maxDistance;
    
    /// <summary>
    /// The world space position of this item.
    /// </summary>
    public Vector2 Position => transform.position;
    

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        InteractManager.OnInteractionSelected += SetSelectedImage;
        InteractManager.OnInteractionUnselected += SetNotSelectedImage;
    }

    private void OnDestroy()
    {
        InteractManager.OnInteractionSelected -= SetSelectedImage;
        InteractManager.OnInteractionUnselected -= SetNotSelectedImage;
    }
    

    /// <summary>
    /// Collects this item.
    /// </summary>
    public void Interact()
    {
        InventoryManager.AddItemToInventory(this, InventoryManager.PlayerInventory);
    }


    private void SetSelectedImage(IInteractive interaction)
    {
        if (interaction as Item == this)
        {
            _spriteRenderer.sprite = _selectedSprite;
        }
    }


    private void SetNotSelectedImage(IInteractive interaction)
    {
        if (interaction as Item == this)
        {
            _spriteRenderer.sprite = _sprite;
        }
    }
    

    #region On Inspector

    [SerializeField] private ItemData _data;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Sprite _selectedSprite;
    [SerializeField] private float _maxDistance;

    #endregion


    private SpriteRenderer _spriteRenderer;

}
