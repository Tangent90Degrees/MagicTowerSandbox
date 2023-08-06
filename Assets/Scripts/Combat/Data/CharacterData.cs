using UnityEngine;

public class CharacterData : ScriptableObject
{
    
    /// <summary>
    /// The name of this character.
    /// </summary>
    public string Name => _name;

    public RaceData Race => _race;

    public CombatValue Talent => _talent;

    public int MaxHealth => Talent * Race.MaxHealth;
    public int MaxMana => Talent * Race.MaxMana;
    public int Attack => Talent * Race.Attack;
    public int MagicalAttack => Talent * Race.MagicalAttack;
    public int Defence => Talent * Race.Defence;
    public int MagicalDefence => Talent * Race.MagicalDefence;
    

    #region On Inspector

    [SerializeField] private string _name;
    [SerializeField] private RaceData _race;
    
    [Header("Character Properties")]
    [SerializeField] private CombatValue _talent;

    #endregion

}
