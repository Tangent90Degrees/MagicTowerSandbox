using System;
using UnityEngine;

/// <summary>
/// A damage records its points, type and dealer.
/// </summary>
[Serializable]
public record Damage
{

    /// <summary>
    /// The points of this damage.
    /// </summary>
    public int Points { get => _points; set => _points = value; }

    /// <summary>
    /// The type of this damage.
    /// </summary>
    public DamageType Type { get => _type; set => _type = value; }


    #region On Inspector

    [SerializeField] private int _points;
    [SerializeField] private DamageType _type;

    #endregion
    
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
