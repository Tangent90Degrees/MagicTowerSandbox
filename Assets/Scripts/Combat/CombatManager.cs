using System;

public class CombatManager : Singleton<CombatManager>
{

    public event Action<CharacterData, Damage> OnDamageDeals;

    public void TakeDamage(CharacterData character, Damage damage)
    {
        switch (damage.Type)
        {
            case DamageType.Physical:
                break;
            case DamageType.Magical:
                break;
            case DamageType.Real:
                break;
        }
        OnDamageDeals?.Invoke(character, damage);
    }
    
}



