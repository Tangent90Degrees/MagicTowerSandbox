using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ItemStack))]
public class ItemStackPropertyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var itemProperty = property.FindPropertyRelative("_item");
        var numberProperty = property.FindPropertyRelative("_number");
        
        return EditorGUI.GetPropertyHeight(itemProperty) + EditorGUI.GetPropertyHeight(numberProperty) + 2;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var itemProperty = property.FindPropertyRelative("_item");
        var numberProperty = property.FindPropertyRelative("_number");

        EditorGUI.PropertyField(position, itemProperty, label, true);
        position.y += EditorGUI.GetPropertyHeight(itemProperty) + 2;
        EditorGUI.PropertyField(position, numberProperty, new GUIContent(" "), true);
    }
}
