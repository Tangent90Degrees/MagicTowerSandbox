using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    
    /// <summary>
    /// The position of the player.
    /// </summary>
    public static Vector2 Position => Instance.transform.position;


    /// <summary>
    /// The inventory of the player.
    /// </summary>
    public static Inventory Inventory => Instance._inventory;


    protected override void Awake()
    {
        base.Awake();

        _inventory = GetComponent<Inventory>();
    }

    private Inventory _inventory;

}
