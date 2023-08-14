using UnityEngine;

/// <summary>
/// Controls player movement.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    
    #region Properties

    /// <summary>
    /// Current move speed of the player.
    /// </summary>
    public float Speed => _speed;

    /// <summary>
    /// Current velocity of the player.
    /// </summary>
    public Vector2 Velocity { get => _rb.velocity; set => _rb.velocity = value; }

    #endregion


    #region Script Cycles

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _anim?.SetFloat("Horizontal", InputManager.Move.x);
        _anim?.SetFloat("Vertical", InputManager.Move.y);
    }

    private void FixedUpdate()
    {
        Velocity = InputManager.Move * Speed;
    }

    #endregion
    

    #region On Inspector

    [SerializeField] private float _speed;

    #endregion


    private Rigidbody2D _rb;
    private Animator _anim;
    
}
