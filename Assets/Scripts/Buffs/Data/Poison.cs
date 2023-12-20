using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/Buff/Poison")]
public class Poison : BuffData
{

    public override void OnBuffUpdate(Buff buff, Character character)
    {
        _time += Time.deltaTime;
        if (_time > _damagePeriod)
        {
            CombatManager.TakeDamage(_damage, character);
            _time = 0;
        }
    }
    
    #region On Inspector

    [Header("Poison")]

    [SerializeField] private Damage _damage;
    [SerializeField] private float _damagePeriod;
    [SerializeField] private float _moveSpeedFactor;

    #endregion

    private float _time;

}
