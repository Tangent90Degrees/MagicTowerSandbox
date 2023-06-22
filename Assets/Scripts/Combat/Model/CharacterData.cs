using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A character combat model.
/// </summary>
[CreateAssetMenu(menuName = "Combat/Character")]
public class CharacterData : ScriptableObject
{
    #region Character Basic Info

    /// <summary>
    /// The name of the Character.
    /// </summary>
    public string Name => _name;

    public SpeciesData Species => _species;

    /// <summary>
    /// The level of the character.
    /// </summary>
    public int Level
    {
        get => _level;
        set => _level = Mathf.Clamp(value, 0, 15);
    }

    #endregion


    #region Talents

    /// <summary>
    /// The strength of the character.
    /// Influences attack, defence and max health.
    /// </summary>
    public int Strength { get => _strength; set => _strength = value; }

    /// <summary>
    /// The flexibility of the character.
    /// Influences attack speed, move speed and critic chance.
    /// </summary>
    public int Flexibility { get => _flexibility; set => _flexibility = value; }

    /// <summary>
    /// The soul of the character.
    /// Influences magic attack and max mana.
    /// </summary>
    public int Soul { get => _soul; set => _soul = value; }

    #endregion


    #region Soul Colors

    public int Red { get => _red; set => _red = value; }
    public int Orange { get => _orange; set => _orange = value; }
    public int Yellow { get => _yellow; set => _yellow = value; }
    public int Green { get => _green; set => _green = value; }
    public int Cyan { get => _cyan; set => _cyan = value; }
    public int Blue { get => _blue; set => _blue = value; }
    public int Purple { get => _purple; set => _purple = value; }

    #endregion


    #region Combat Properties

    public int Attack => Species.Attack(this)
    + (Head ? Head.Attack(this) : 0)
    + (Armor ? Armor.Attack(this) : 0)
    + (Legs ? Legs.Attack(this) : 0)
    + (Boots ? Boots.Attack(this) : 0)
    + (Accessory ? Accessory.Attack(this) : 0)
    + (Weapon ? Weapon.Attack(this) : 0);

    #endregion


    #region Equipments
    public EquipmentData Head { get => _head; set => _head = value; }
    public EquipmentData Armor { get => _armor; set => _armor = value; }
    public EquipmentData Legs { get => _legs; set => _legs = value; }
    public EquipmentData Boots { get => _boots; set => _boots = value; }
    public EquipmentData Accessory { get => _accessory; set => _accessory = value; }
    public EquipmentData Weapon { get => _weapon; set => _weapon = value; }

    #endregion


    #region On Inspector

    [Header("Character")]
    [SerializeField] private string _name;
    [SerializeField] private SpeciesData _species;
    [SerializeField] private int _level;

    [Header("Talents")]
    [SerializeField] private int _strength;
    [SerializeField] private int _flexibility;
    [SerializeField] private int _soul;

    [Header("Soul Colors")]
    [SerializeField] private int _red;
    [SerializeField] private int _orange;
    [SerializeField] private int _yellow;
    [SerializeField] private int _green;
    [SerializeField] private int _cyan;
    [SerializeField] private int _blue;
    [SerializeField] private int _purple;

    [Header("Equipments")]
    [SerializeField] private EquipmentData _head;
    [SerializeField] private EquipmentData _armor;
    [SerializeField] private EquipmentData _legs;
    [SerializeField] private EquipmentData _boots;
    [SerializeField] private EquipmentData _accessory;
    [SerializeField] private EquipmentData _weapon;

    #endregion
}
