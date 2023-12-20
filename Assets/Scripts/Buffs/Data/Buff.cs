using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Buff
{

    public Buff(BuffData data)
    {
        Data = data;
        StackTimes = 1;
        Time = MaxStackTimes;
    }


    public BuffData Data
    {
        get => _data;
        init => _data = value;
    }

    public int StackTimes
    {
        get => _stackTimes;
        set => _stackTimes = Mathf.Clamp(value, 1, MaxStackTimes);
    }

    public float Time { get; set; }
    public bool IsFading { get; set; }

    public bool Ends => Data.IsTiming && StackTimes == 1 && Time < 0;
    public bool Fades => Data.IsTiming && StackTimes > 1 && Time < 0;


    /// <summary>
    /// The identifiable name of this buff.
    /// </summary>
    public string Name => Data.Name;

    /// <summary>
    /// The type of this buff.
    /// </summary>
    public BuffType Type => _data.Type;

    /// <summary>
    /// The icon of this buff.
    /// </summary>
    public Sprite Icon => _data.Icon;

    /// <summary>
    /// The max stack times of this buff.
    /// </summary>
    public int MaxStackTimes => _data.MaxStackTimes;

    public bool IsTiming => Data.IsTiming;
    public float LastTime => Data.LastTime;
    public float FadingTime => Data.FadingTime;


    public void Update(Character character)
    {
        Data.OnBuffUpdate(this, character);
    }

    public void OnBasicAttacking(Character character)
    {
        Data.OnBasicAttacking(this, character);
    }

    public void OnSkilling(Character character)
    {
        Data.OnSkilling(this, character);
    }

    public virtual void OnDealingDamage(Character character, Damage damage)
    {
        Data.OnDealingDamage(this, character, damage);
    }

    public virtual void AfterDealingDamage(Character character, Damage damage, Character to)
    {
        Data.AfterDealingDamage(this, character, damage, to);
    }

    public virtual void OnDamageTaken(Character character, Damage damage)
    {
        Data.OnDamageTaken(this, character, damage);
    }

    public virtual void AfterDamageTaken(Character character, Damage damage, Character from)
    {
        Data.AfterDamageTaken(this, character, damage, from);
    }

    
    #region On Inspector

    [SerializeField] private BuffData _data;
    [SerializeField] private int _stackTimes;

    #endregion

}
