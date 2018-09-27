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

        if (!disabled)
            EditorGUILayout.PropertyField(script, new GUIContent("Changeable Script"));

        base.OnInspectorGUI();

        if (EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();
    }
}
