using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EaseFunctionTest), true)]
public class EaseFunctionTestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Go"))
        {
            if (Application.isPlaying)
            {
                EaseFunctionTest t = target as EaseFunctionTest;
                t.BeginTween();
            }
        }   
    }
}
