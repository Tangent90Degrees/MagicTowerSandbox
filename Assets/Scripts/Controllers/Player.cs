using UnityEngine;

public class Player : Character
{

    /// <summary>
    /// The inventory of the player.
    /// </summary>
    public Inventory Inventory => _inventory;
    
    public PlayerMovement Movement => _movement;


    private void Awake()
    {
        GameManager.RegisterPlayer(this);

        _inventory = GetComponent<Inventory>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void OnDistroy()
    {
        GameManager.RegisterPlayer(null);
    }

    private PlayerMovement _movement;
    private Inventory _inventory;

}
