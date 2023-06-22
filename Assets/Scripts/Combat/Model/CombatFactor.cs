using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// A group of factors depending on character strength, flexibility and soul.
/// </summary>
[System.Serializable]
public record CombatFactor
{
    /// <summary>
    /// The strength factor of the addtional value.
    /// </summary>
    public int Strength => _strength;

    /// <summary>
    /// The flexibility factor of the addtional value.
    /// </summary>
    public int Flexibility => _flexibility;

    /// <summary>
    /// The soul factor of the addtional value.
    /// </summary>
    public int Soul => _soul;

    /// <summary>
    /// Get the additonal value of the specific character state.
    /// </summary>
    public int Of(CharacterData character)
    {
        return (Strength * character.Strength + Flexibility * character.Flexibility + Soul * character.Soul) / 100;
    }

    [Header("Combat Factor")]
    [SerializeField] private int _strength;
    [SerializeField] private int _flexibility;
    [SerializeField] private int _soul;

    [Header("Color Factor")]
    [SerializeField] private int _red;
    [SerializeField] private int _orange;
    [SerializeField] private int _yellow;
    [SerializeField] private int _green;
    [SerializeField] private int _cyan;
    [SerializeField] private int _blue;
    [SerializeField] private int _purple;
}


/// <summary>
/// The property drawer of CombatFactors.
/// </summary>
// [CustomPropertyDrawer(typeof(CombatFactor))]
// public class CombatFactorPropertyDrawer : PropertyDrawer
// {
//     public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//     {
//         EditorGUI.BeginProperty(position, label, property);
//         position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

//         var strengthProperty = property.FindPropertyRelative("_strength");
//         var flexibilityProperty = property.FindPropertyRelative("_flexibility");
//         var soulProperty = property.FindPropertyRelative("_soul");

//         float eachWidth = (position.width - 2 * _spaceWidth) / 3;

//         Rect labelRect = new(position.x, position.y, _labelWidth, position.height);
//         Rect fieldRect = new(position.x + _labelWidth, position.y, eachWidth - _labelWidth, position.height);

//         EditorGUI.LabelField(labelRect, "STR");
//         EditorGUI.PropertyField(fieldRect, strengthProperty, GUIContent.none);

//         labelRect.x += eachWidth + _spaceWidth;
//         fieldRect.x += eachWidth + _spaceWidth;

//         EditorGUI.LabelField(labelRect, "FLX");
//         EditorGUI.PropertyField(fieldRect, flexibilityProperty, GUIContent.none);

//         labelRect.x += eachWidth + _spaceWidth;
//         fieldRect.x += eachWidth + _spaceWidth;

//         EditorGUI.LabelField(labelRect, "INT");
//         EditorGUI.PropertyField(fieldRect, soulProperty, GUIContent.none);

//         EditorGUI.EndProperty();
//     }

//     private const float _labelWidth = 30;
//     private const float _spaceWidth = 3;
// }