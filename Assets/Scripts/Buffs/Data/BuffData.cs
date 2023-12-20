using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffData : ScriptableObject
{

    /// <summary>
    /// The identifiable name of this buff.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// The type of this buff.
    /// </summary>
    public BuffType Type => _type;

    /// <summary>
    /// The icon of this buff.
    /// </summary>
    public Sprite Icon => _icon;

    /// <summary>
    /// The max stack times of this buff.
    /// </summary>
    public int MaxStackTimes => _maxStackTimes;

    public bool IsTiming => _isTiming;
    public float LastTime => _lastTime;
    public float FadingTime => _fadingTime;


    public virtual void OnBuffUpdate(Buff buff, Character character)
    {
    }

    public virtual void OnBasicAttacking(Buff buff, Character character)
    {
    }

    public virtual void OnSkilling(Buff buff, Character character)
    {
    }

    public virtual void OnDealingDamage(Buff buff, Character character, Damage damage)
    {
    }

    public virtual void AfterDealingDamage(Buff buff, Character character, Damage damage, Character to)
    {
    }

    public virtual void OnDamageTaken(Buff buff, Character character, Damage damage)
    {
    }

    public virtual void AfterDamageTaken(Buff buff, Character character, Damage damage, Character from)
    {
    }

    
    #region On Inspector

    [Header("Basic Information")]

    [SerializeField] private string _name;
    [SerializeField] private BuffType _type;
    [SerializeField] private Sprite _icon;

    [Header("Buff Settings")]

    [SerializeField] private int _maxStackTimes;
    [SerializeField] private bool _isTiming;
    [SerializeField] private float _lastTime;
    [SerializeField] private float _fadingTime;

    #endregion

}


public enum BuffType
{
    Positive,
    Neutral,
    Nagative
}