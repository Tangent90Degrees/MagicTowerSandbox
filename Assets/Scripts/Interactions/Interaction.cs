using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public abstract class Interaction : MonoBehaviour, IPointerClickHandler
{

    /// <summary>
    /// This method is called once interacts.
    /// </summary>
    public abstract void Interact();

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this == InteractManager.SelectedInteraction)
        {
            Interact();
        }
    }

    public virtual void OnSelected()
    {
    }

    public virtual void OnUnselected()
    {
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == InteractManager.Player)
        {
            InteractManager.Select(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == InteractManager.Player)
        {
            InteractManager.Unselect(this);
        }
    }

}
