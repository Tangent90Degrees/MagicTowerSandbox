using System.Collections;
using System.Collections.Generic;
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

    /// <summary>
    /// Get the normalized direction vector from key inputs.
    /// </summary>
    private Vector2 DirectionInput => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

    #endregion


    #region Script Cycles

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _anim?.SetFloat("Horizontal", DirectionInput.x);
        _anim?.SetFloat("Vertical", DirectionInput.y);
    }

    private void FixedUpdate()
    {
        Velocity = DirectionInput * Speed;
    }

    #endregion
    

    #region On Inspector

    [SerializeField] private float _speed;

    #endregion

    private Rigidbody2D _rb;
    private Animator _anim;
}
