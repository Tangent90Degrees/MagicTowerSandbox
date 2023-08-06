using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A period of dialogue.
/// </summary>
[CreateAssetMenu(menuName = "Dialogue")]
public class DialogueData : ScriptableObject
{
    
    /// <summary>
    /// The list of all turns.
    /// </summary>
    public List<DialogueTurn> Turns => _turns;

    /// <summary>
    /// The list of all options.
    /// </summary>
    public List<DialogueOption> Options => _options;
    

    /// <summary>
    /// If this dialogue starts a new dialogue.
    /// </summary>
    public bool Ends => Options.Count == 0;
    

    #region On Inspector

    [SerializeField] private List<DialogueTurn> _turns;
    [SerializeField] private List<DialogueOption> _options;

    #endregion

}


/// <summary>
/// A dialogue turn records someone said something.
/// </summary>
[Serializable]
public class DialogueTurn
{
    
    /// <summary>
    /// Initializes a new turn instance with the specified character and content.
    /// </summary>
    public DialogueTurn(CharacterData character, string content)
    {
        Character = character;
        Content = content;
    }
    

    /// <summary>
    /// The talking character of this turn.
    /// </summary>
    public CharacterData Character
    {
        get => _character;
        init => _character = value;
    }

    /// <summary>
    /// The content this turn says.
    /// </summary>
    public string Content
    {
        get => _content;
        init => _content = value;
    }
    

    #region On Inspector

    [SerializeField] private CharacterData _character;
    [SerializeField, TextArea] private string _content;

    #endregion
    
}


/// <summary>
/// An option player can make to start a new dialogue.
/// </summary>
[Serializable]
public class DialogueOption
{
    
    /// <summary>
    /// Initializes a new option instance with the specified receive message and dialogue.
    /// </summary>
    public DialogueOption(string content, DialogueData nextDialogue)
    {
        Content = content;
        NextDialogue = nextDialogue;
    }
    

    /// <summary>
    /// The receive message of this turn says.
    /// </summary>
    public string Content
    {
        get => _content;
        init => _content = value;
    }

    /// <summary>
    /// The next dialogue this option starts.
    /// </summary>
    public DialogueData NextDialogue
    {
        get => _nextDialogue;
        init => _nextDialogue = value;
    }


    #region On Inspector

    [SerializeField, TextArea] private string _content;
    [SerializeField] private DialogueData _nextDialogue;

    #endregion

}