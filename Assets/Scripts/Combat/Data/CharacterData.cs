using UnityEngine;
using UnityEngine.Serialization;

public class CharacterData : ScriptableObject
{
    
    /// <summary>
    /// The name of this character.
    /// </summary>
    public string Name => _name;

    public RaceData Race => _race;

    public int MaxHealth => _talent * Race.MaxHealth;
    public int MaxMana => _talent * Race.MaxMana;

    #region On Inspector

    [SerializeField] private string _name;
    [SerializeField] private RaceData _race;
    
    [Header("Character Properties")]
    [SerializeField] private CombatValue _talent;

    #endregion

}
