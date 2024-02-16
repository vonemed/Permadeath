using ConfigScripts;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(BoosterConfig))]
public class BoosterConfigEditor : Editor
{
    public override void OnInspectorGUI()
    {
        
        // Draw the ScriptableObject's inspector
        // editorInstance.DrawDefaultInspector();
        base.OnInspectorGUI();
    }
}