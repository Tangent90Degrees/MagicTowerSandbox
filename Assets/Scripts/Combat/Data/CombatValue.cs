using System;
using UnityEngine;

[Serializable]
public struct CombatValue
{
    
    public CombatValue(int strength, int flexibility, int intelligence)
    {
        Strength = strength;
        Flexibility = flexibility;
        Intelligence = intelligence;
    }
    
    
    [field: SerializeField]
    public int Strength { get; set; }
    
    [field: SerializeField]
    public int Flexibility { get; set; }
    
    [field: SerializeField]
    public int Intelligence { get; set; }
    
    
    public static int operator *(CombatValue lhs, CombatValue rhs)
    {
        return 
            (lhs.Strength * rhs.Strength 
             + lhs.Flexibility * rhs.Flexibility 
             + lhs.Intelligence * rhs.Intelligence) 
            / 100;
    }
    
    public static CombatValue operator +(CombatValue lhs, CombatValue rhs)
    {
        return new CombatValue
        (
            lhs.Strength + rhs.Strength, 
            lhs.Flexibility + rhs.Flexibility, 
            lhs.Intelligence + rhs.Intelligence
        );
    }
    
}
