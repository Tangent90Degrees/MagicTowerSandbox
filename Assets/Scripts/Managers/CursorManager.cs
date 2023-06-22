using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The manager of cursor move and mouse click events.
/// </summary>
public class CursorManager : Singleton<CursorManager>
{

    /// <summary>
    /// This event invokes when mouse clicked.
    /// </summary>
    public static event Action OnMouseClicked;

    /// <summary>
    /// The screen point of cursor position.
    /// </summary>
    public static Vector2 PositionOnScreen => Input.mousePosition;

    /// <summary>
    /// The world point of cursor position.
    /// </summary>
    public static Vector2 PositionInWorld => Camera.main.ScreenToWorldPoint(PositionOnScreen);

    /// <summary>
    /// The collider at current cursor point.
    /// </summary>
    public static Collider2D ColliderOnCursor => Physics2D.OverlapPoint(PositionInWorld);


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClicked?.Invoke();

            IMouseClickable clickableObject = ColliderOnCursor.GetComponent<IMouseClickable>();
            clickableObject?.OnMouseClicked();
        }
    }

}


public interface IMouseClickable
{
    public void OnMouseClicked();
}