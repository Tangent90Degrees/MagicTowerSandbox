using UnityEngine;

/// <summary>
/// The race defines combat talent bonus of characters.
/// </summary>
[CreateAssetMenu(menuName = "Combat/Race")]
public class RaceData : ScriptableObject
{

    /// <summary>
    /// The name of this race.
    /// </summary>
    public string Name => _name;
    
    /// <summary>
    /// The icon of this race.
    /// </summary>
    public Sprite Icon => _icon;
    
    /// <summary>
    /// The description of this race.
    /// </summary>
    public string Description => _description;


    /// <summary>
    /// The max health bonus of this race.
    /// </summary>
    public CombatValue MaxHealth => _maxHealth;
    
    /// <summary>
    /// The max mana bonus of this race.
    /// </summary>
    public CombatValue MaxMana => _maxMana;
    
    /// <summary>
    /// The attack bonus of this race.
    /// </summary>
    public CombatValue Attack => _attack;
    
    /// <summary>
    /// The magical attack bonus of this race.
    /// </summary>
    public CombatValue MagicalAttack => _magicalAttack;
    
    /// <summary>
    /// The defence bonus of this race.
    /// </summary>
    public CombatValue Defence => _defence;
    
    /// <summary>
    /// The magical defence bonus of this race.
    /// </summary>
    public CombatValue MagicalDefence => _magicalDefence;
    
    /// <summary>
    /// The move speed bonus of this race.
    /// </summary>
    public CombatValue MoveSpeed => _moveSpeed;
    
    /// <summary>
    /// The attack speed bonus of this race.
    /// </summary>
    public CombatValue AttackSpeed => _attackSpeed;

    
    #region On Inspector

    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _description;

    [Header("Combat Bonus")]
    
    [SerializeField] private CombatValue _maxHealth;
    [SerializeField] private CombatValue _maxMana;

    [SerializeField] private CombatValue _attack;
    [SerializeField] private CombatValue _magicalAttack;

    [SerializeField] private CombatValue _defence;
    [SerializeField] private CombatValue _magicalDefence;

    [SerializeField] private CombatValue _moveSpeed;
    [SerializeField] private CombatValue _attackSpeed;

    #endregion

}
