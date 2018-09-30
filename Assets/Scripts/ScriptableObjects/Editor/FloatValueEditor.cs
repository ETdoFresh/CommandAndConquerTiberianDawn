using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(FloatValue), true)]
public class FloatValueEditor : PropertyDrawer
{
    SerializedObject serializedObject = null;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.objectReferenceValue != null)
        {
            if (serializedObject == null || serializedObject.targetObject != property.objectReferenceValue)
                serializedObject = new SerializedObject(property.objectReferenceValue);
        }
        else
            serializedObject = null;

        if (serializedObject != null)
        {
            EditorGUI.BeginChangeCheck();

            var rect = new Rect(position.x, position.y, position.width * 3 / 4, position.height);
            EditorGUI.PropertyField(rect, property);
            var valueProperty = serializedObject.FindProperty("value");
            rect = new Rect(position.width * 3 / 4 + 15, position.y, position.width * 1 / 4 - 15, position.height);
            EditorGUI.PropertyField(rect, valueProperty, GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }
        else
            EditorGUI.PropertyField(position, property);
    }
}
