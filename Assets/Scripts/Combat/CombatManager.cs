using System;

public class CombatManager : Singleton<CombatManager>
{

    public event Action<CharacterData, Damage> OnDamageDeals;

    public static void DealDamage(Character from, Damage damage, Character to)
    {
        from.DealDamage(damage, to);
    }

    public static void TakeDamage(Damage damage, Character to)
    {
        to.TakeDamage(damage);
    }
    
}



