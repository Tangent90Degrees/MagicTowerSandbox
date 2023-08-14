using UnityEngine;

public class CharacterData : ScriptableObject
{
    
    /// <summary>
    /// The name of this character.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// The race of this character.
    /// </summary>
    public RaceData Race => _race;
    

    #region Talents

    /// <summary>
    /// 3 basic talents of this character.
    /// </summary>
    private CombatValue Talent => _talent;

    /// <summary>
    /// The strength of this character.
    /// </summary>
    public int Strength { get => _talent.Strength; set => _talent.Strength = value; }
    
    /// <summary>
    /// The flexibility of this character. 
    /// </summary>
    public int Flexibility { get => _talent.Flexibility; set => _talent.Flexibility = value; }
    
    /// <summary>
    /// The intelligence of this character.
    /// </summary>
    public int Intelligence { get => _talent.Intelligence; set => _talent.Intelligence = value; }
    
    #endregion


    #region Combat Properties
    
    public int MaxHealth => Talent * Race.MaxHealth;
    public int MaxMana => Talent * Race.MaxMana;
    public int Attack => Talent * Race.Attack;
    public int MagicalAttack => Talent * Race.MagicalAttack;
    public int Defence => Talent * Race.Defence;
    public int MagicalDefence => Talent * Race.MagicalDefence;
    public int MoveSpeed => Talent * Race.MoveSpeed;
    public int AttackSpeed => Talent * Race.AttackSpeed;
    
    #endregion
    

    #region On Inspector

    [SerializeField] private string _name;
    [SerializeField] private RaceData _race;
    
    [Header("Character Properties")]
    [SerializeField] private CombatValue _talent;

    #endregion

}
