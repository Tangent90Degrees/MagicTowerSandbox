using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TriggerEvent : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        _onEnter?.Invoke(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _onExit.Invoke(other);
    }


    #region On Inspector

    [SerializeField] private UnityEvent<Collider2D> _onEnter;
    [SerializeField] private UnityEvent<Collider2D> _onExit;

    #endregion

}
