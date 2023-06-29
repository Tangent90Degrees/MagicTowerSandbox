using System;

/// <summary>
/// A damage records its points, type and dealer.
/// </summary>
[Serializable]
public record Damage
{

    /// <summary>
    /// The points of this damage.
    /// </summary>
    public int Points { get; private set; }
    
    /// <summary>
    /// The type of this damage.
    /// </summary>
    public DamageType Type { get; private set; }
    
    /// <summary>
    /// The data of dealer of this damage.
    /// </summary>
    public CharacterData Dealer { get; private set; }
    
}


/// <summary>
/// A type of damage.
/// </summary>
public enum DamageType
{
    Physical,
    Magical,
    Real
}
