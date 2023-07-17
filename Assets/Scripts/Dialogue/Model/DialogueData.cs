using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]
public class DialogueData : ScriptableObject
{
    
    public List<DialogueTurn> Turns => _turns;

    public List<DialogueOption> Options => _options;
    

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
    
    
    [SerializeField] private CharacterData _character;
    [SerializeField, TextArea] private string _content;
    
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
    public DialogueOption(string content, DialogueData startingDialogue)
    {
        Content = content;
        StartingDialogue = startingDialogue;
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
    public DialogueData StartingDialogue
    {
        get => _startingDialogue;
        init => _startingDialogue = value;
    }


    [SerializeField, TextArea] private string _content;
    [SerializeField] private DialogueData _startingDialogue;

}