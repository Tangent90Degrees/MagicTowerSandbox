using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class BuffHandler : MonoBehaviour
{

    public Character Character => _character;
    public List<Buff> Buffs => _buffs;


    public void AddBuff(BuffData buff)
    {
        var target = Buffs.Find(i => i.Data == buff);
        if (buff == null)
        {
            Buffs.Add(new Buff(buff));
        }
        else
        {
            target.StackTimes++;
            target.Time = target.LastTime;
        }
    }

    public void RemoveBuff(BuffData buff)
    {
        var target = Buffs.Find(i => i.Data == buff);
        if (target != null)
        {
            Buffs.Remove(target);
        }
    }


    private void Awake()
    {
        _character = GetComponent<Character>();
    }

    private void OnEnable()
    {
        Character.OnDealingDamage += OnDealingDamage;
        Character.AfterDealingDamage += AfterDealingDamage;
    }

    private void Update()
    {
        foreach (var buff in Buffs)
        {
            buff.Time -= Time.deltaTime;

            if (buff.Fades)
            {
                buff.Time = buff.FadingTime;
                buff.StackTimes--;
                buff.IsFading = true;
            }
            else if (buff.Ends)
            {
                Buffs.Remove(buff);
            }
        }

        Buffs.ForEach(i => i.Update(Character));
    }


    private void OnBasicAttacking()
    {
        Buffs.ForEach(i => i.OnBasicAttacking(Character));
    }

    private void OnSkilling()
    {
        Buffs.ForEach(i => i.OnSkilling(Character));
    }

    private void OnDealingDamage(Damage damage)
    {
        Buffs.ForEach(i => i.OnDealingDamage(Character, damage));
    }

    private void AfterDealingDamage(Damage damage, Character to)
    {
        Buffs.ForEach(i => i.AfterDealingDamage(Character, damage, to));
    }

    private void OnDamageTaken(Damage damage)
    {
        Buffs.ForEach(i => i.OnDamageTaken(Character, damage));
    }

    private void AfterDamageTaken(Damage damage, Character from)
    {
        Buffs.ForEach(i => i.AfterDamageTaken(Character, damage, from));
    }

    
    [SerializeField] private List<Buff> _buffs;

    private Character _character;

}
