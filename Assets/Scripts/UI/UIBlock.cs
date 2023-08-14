using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// A UI block that can be selected by cursor.
/// </summary>
public class UIBlock : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    /// <summary>
    /// This event invokes when this UI block interacts.
    /// </summary>
    public UnityEvent OnInteracting => _onInteracting;
    
    /// <summary>
    /// This event invokes when this block is selected.
    /// </summary>
    public UnityEvent OnSelected => _onSelected;
    
    /// <summary>
    /// This event invokes when this block is unselected
    /// </summary>
    public UnityEvent OnUnselected => _onUnselected;


    /// <summary>
    /// This method is called by UIManager when this UI block interacts.
    /// </summary>
    public void Interact()
    {
        OnInteracting?.Invoke();
    }

    /// <summary>
    /// This method is called by UIManager when this block is selected. 
    /// </summary>
    public void Select()
    {
        _onSelected?.Invoke();
    }

    /// <summary>
    /// This method is called by UIManager when this block is unselected.
    /// </summary>
    public void Unselect()
    {
        _onUnselected?.Invoke();
    }


    #region Pointer Handlers

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.SelectedBlock = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.SelectedBlock = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Interact();
    }

    #endregion


    #region On Inspector

    [Header("UI Block Events")]

    [SerializeField] private UnityEvent _onInteracting;
    [SerializeField] private UnityEvent _onSelected;
    [SerializeField] private UnityEvent _onUnselected;

    #endregion

}
