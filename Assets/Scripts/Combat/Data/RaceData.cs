using UnityEngine;

/// <summary>
/// The race defines combat talent bonus of characters.
/// </summary>
[CreateAssetMenu(menuName = "Combat/Race")]
public class RaceData : ScriptableObject
{

    /// <summary>
    /// The max health bonus of this race.
    /// </summary>
    public CombatValue MaxHealth => _maxHealth;
    
    /// <summary>
    /// The max mana bonus of this race.
    /// </summary>
    public CombatValue MaxMana => _maxMana;
    
    public CombatValue Attack => _attack;
    public CombatValue MagicalAttack => _magicalAttack;
    
    public CombatValue Defence => _defence;
    public CombatValue MagicalDefence => _magicalDefence;
    
    public CombatValue MoveSpeed => _moveSpeed;
    public CombatValue AttackSpeed => _attackSpeed;
    

    #region On Inspector
    
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
