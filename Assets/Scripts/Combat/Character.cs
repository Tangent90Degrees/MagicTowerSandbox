using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A character with its health data.
/// </summary>
public class Character : MonoBehaviour
{

    public event Action<Damage> OnDealingDamage;
    public event Action<Damage, Character> AfterDealingDamage;
    public event Action<Damage> OnDamageTaken;
    public event Action<Damage, Character> AfterDamageTaken;
    

    public CharacterData Data => _data;

    public int MaxHealth => Data.MaxHealth;

    public int Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0, MaxHealth);
    }

    public void DealDamage(Damage damage, Character to)
    {
        OnDealingDamage?.Invoke(damage);
        to.TakeDamage(damage, this);
        AfterDealingDamage?.Invoke(damage, to);
    }

    public void TakeDamage(Damage damage)
    {
        OnDamageTaken?.Invoke(damage);
        Health -= damage.Points;
        AfterDamageTaken?.Invoke(damage, null);
    }

    private void TakeDamage(Damage damage, Character from)
    {
        OnDamageTaken?.Invoke(damage);
        Health -= damage.Points;
        AfterDamageTaken?.Invoke(damage, from);
    }

    
    #region On Inspector

    [SerializeField] private CharacterData _data;

    [SerializeField] private int _health;

    #endregion

}
