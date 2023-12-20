using UnityEngine;

/// <summary>
/// An item can be stored in an inventory.
/// </summary>
[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    
    /// <summary>
    /// The name of this item.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// The icon shown on UI.
    /// </summary>
    public Sprite Icon => _icon;

    /// <summary>
    /// The description of this item.
    /// </summary>
    public string Description => _description;

    /// <summary>
    /// The maximum number of this item in stacks.
    /// </summary>
    public int MaxStackTimes => _maxStackTimes;


    #region On Inspector
    
    [Header("Item Information")]
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField, TextArea] private string _description;
    [SerializeField] private int _maxStackTimes;
    
    #endregion

}
