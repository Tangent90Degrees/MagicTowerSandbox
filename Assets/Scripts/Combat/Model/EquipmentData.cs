using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An Equipment can add combat ability of a character.
/// </summary>
[CreateAssetMenu(menuName = "Combat/Equipment")]
public class EquipmentData : ItemData
{
    /// <summary>
    /// The attack additional value of the specific character.
    /// </summary>
    public int Attack(CharacterData character) => _attack.Of(character);

    /// <summary>
    /// The magic attack additional value of the specific character.
    /// </summary>
    public int MagicAttack(CharacterData character) => _magicAttack.Of(character);

    /// <summary>
    /// The attack speed additional value of the specific character.
    /// </summary>
    public int AttackSpeed(CharacterData character) => _attackSpeed.Of(character);

    /// <summary>
    /// The critic chance additional value of the specific character.
    /// </summary>
    public int CriticChance(CharacterData character) => _criticChance.Of(character);

    /// <summary>
    /// The defence additional value of the specific character.
    /// </summary>
    public int Defence(CharacterData character) => _defence.Of(character);

    /// <summary>
    /// The magic defence additional value of the specific character.
    /// </summary>
    public int MagicDefence(CharacterData character) => _magicDefence.Of(character);

    /// <summary>
    /// The move speed additional value of the specific character.
    /// </summary>
    public int MoveSpeed(CharacterData character) => _moveSpeed.Of(character);

    /// <summary>
    /// The max health additional value of the specific character.
    /// </summary>
    public int MaxHealth(CharacterData character) => _maxHealth.Of(character);

    /// <summary>
    /// The max mana additional value of the specific character.
    /// </summary>
    public int MaxMana(CharacterData character) => _maxMana.Of(character);
    
    [Header("Equipment Bonus")]
    [Space, SerializeField] private CombatFactor _attack;
    [Space, SerializeField] private CombatFactor _magicAttack;
    [Space, SerializeField] private CombatFactor _attackSpeed;
    [Space, SerializeField] private CombatFactor _criticChance;
    [Space, SerializeField] private CombatFactor _defence;
    [Space, SerializeField] private CombatFactor _magicDefence;
    [Space, SerializeField] private CombatFactor _moveSpeed;
    [Space, SerializeField] private CombatFactor _maxHealth;
    [Space, SerializeField] private CombatFactor _maxMana;
}
