using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CreateNeptune
{
    // This is a custom editor for the CNTime class so that you can easily add or subtract time with GUI buttons
    [CustomEditor(typeof(CNTime))]
    public class CNTimeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            // This draws the default inspector window for the class 
            DrawDefaultInspector();

            // This gets the CNTime instance that the editor is attached to
            CNTime cnTimeScript = (CNTime)target;

            // This updates the serialized object that corresponds to this instance
            serializedObject.Update();

            // Below are the various buttons to add or subtract time
            AddButton("Add Minute", cnTimeScript, 60);

            AddButton("Add Hour", cnTimeScript, 3600);

            AddButton("Add Day", cnTimeScript, 86400);

            AddButton("Add Week", cnTimeScript, 604800);

            AddButton("Subtract Minute", cnTimeScript, -60);

            AddButton("Subtract Hour", cnTimeScript, -3600);

            AddButton("Subtract Day", cnTimeScript, -86400);

            AddButton("Subtract Week", cnTimeScript, -604800);

            // This applies the changes to the serialized object
            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// This is a helper method to add each of the buttons to the editor
        /// </summary>
        private void AddButton(string label, CNTime cnTimeScript, double timeToAdd)
        {
            if (GUILayout.Button(label))
            {
                // First, we record this action so that it can be undone with cmd/ctrl + z
                Undo.RecordObject(cnTimeScript, label);
                
                // Then, we apply the change to the time offset
                cnTimeScript.timeOffsetInSeconds += timeToAdd;
                
                // Finally, we mark the object as dirty so that the editor knows the change needs to be saved
                EditorUtility.SetDirty(cnTimeScript);
            }
        }
    }
}
