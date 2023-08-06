using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpeaker : MonoBehaviour, IInteractive
{

    public DialogueData Dialogue => _dialogue;


    #region IInteractive

    public float MaxDistance => DialogueManager.MaxDialogueDistance;
    public Vector2 Position => transform.position;
    
    public void Interact()
    {
        DialogueManager.Dialogue = Dialogue;
    }

    #endregion


    #region On Inspector

    [SerializeField] private DialogueData _dialogue;

    #endregion

}
