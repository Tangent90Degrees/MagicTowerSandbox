using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Equipment")]
public class EquipmentData : ItemData
{

    /// <summary>
    /// The max health bonus of this equipment.
    /// </summary>
    public CombatValue MaxHealth => _maxHealth;
    
    /// <summary>
    /// The max mana bonus of this equipment.
    /// </summary>
    public CombatValue MaxMana => _maxMana;
    
    /// <summary>
    /// The attack bonus of this equipment.
    /// </summary>
    public CombatValue Attack => _attack;
    
    /// <summary>
    /// The magical attack bonus of this equipment.
    /// </summary>
    public CombatValue MagicalAttack => _magicalAttack;
    
    /// <summary>
    /// The defence bonus of this equipment.
    /// </summary>
    public CombatValue Defence => _defence;
    
    /// <summary>
    /// The magical defence bonus of this equipment.
    /// </summary>
    public CombatValue MagicalDefence => _magicalDefence;
    
    /// <summary>
    /// The move speed bonus of this equipment.
    /// </summary>
    public CombatValue MoveSpeed => _moveSpeed;
    
    /// <summary>
    /// The attack speed bonus of this equipment.
    /// </summary>
    public CombatValue AttackSpeed => _attackSpeed;

    
    #region On Inspector

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
