using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpeaker : Interaction
{

    public DialogueData Dialogue => _dialogue;


    #region Interaction

    public override void Interact()
    {
        DialogueManager.Dialogue = Dialogue;
    }

    #endregion


    #region On Inspector

    [SerializeField] private DialogueData _dialogue;

    #endregion

}
