using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScriptableObject), true)]
public class ScriptableObjectChangeableScript : Editor
{
    private bool disabled = false;
    private SerializedProperty script;

    private void OnEnable()
    {
        script = serializedObject.FindProperty("m_Script");
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        EditorGUI.BeginDisabledGroup(disabled);
        EditorGUILayout.PropertyField(script);
        EditorGUI.EndDisabledGroup();
        if (EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();
    }
}
