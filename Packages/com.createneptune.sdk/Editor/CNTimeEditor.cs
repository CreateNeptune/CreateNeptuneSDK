using UnityEngine;
using UnityEditor;
using System;

namespace CreateNeptune
{
    // This custom editor is used to display the adjusted timestamp and allow for easy adjustment of the time offset
    [CustomEditor(typeof(CNTime), true)] 
    public class TimeEditorInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            // This draws the default inspector window for the class 
            DrawDefaultInspector();

            // This gets the CNTime instance that the editor is attached to
            CNTime cnTimeScript = (CNTime)target;

            // This updates the serialized object that corresponds to this instance
            serializedObject.Update();

            // Displays the adjusted timestamp
            GUIStyle centeredLabelStyle = new GUIStyle(EditorStyles.boldLabel);
            centeredLabelStyle.alignment = TextAnchor.MiddleCenter;
            GUILayout.Label("Adjusted Timestamp", centeredLabelStyle);
            GUILayout.Box(DateTime.Now.AddSeconds(cnTimeScript.timeOffsetInSeconds).ToString("MM/dd/yyyy HH:mm:ss"), GUILayout.ExpandWidth(true));

            // This style gets used for all the increment/decrement fields
            GUIStyle centeredFieldStyle = new GUIStyle(GUI.skin.textField);
            centeredFieldStyle.alignment = TextAnchor.MiddleCenter;

            // Increment/Decrement controls for Weeks, Days, Hours
            DrawAdjustmentField("Weeks", centeredFieldStyle, ref cnTimeScript.weeks);
            DrawAdjustmentField("Days", centeredFieldStyle, ref cnTimeScript.days);
            DrawAdjustmentField("Hours", centeredFieldStyle, ref cnTimeScript.hours);
            DrawAdjustmentField("Minutes", centeredFieldStyle, ref cnTimeScript.minutes);

            // This applies the changes to the serialized object
            serializedObject.ApplyModifiedProperties();
        }

        // This method draws a field with a label, increment and decrement buttons, and an editable text field
        private void DrawAdjustmentField(string label, GUIStyle fieldTextStyle, ref double value)
        {
            // This keeps everything on the same line
            GUILayout.BeginHorizontal();

            // Starting with a flexible space allows the label to be centered
            GUILayout.FlexibleSpace();

            // Draw the label and set its size (arbitrarily chose 50)
            GUILayout.Label(label, GUILayout.Width(50));

            // Draws a decrement button that decreases the value by 1
            if (GUILayout.Button("<", GUILayout.Width(25)))
            {
                value -= 1.0;
            }

            // Draws an editable text field that displays the value (so it can also be edited manually)
            value = EditorGUILayout.DoubleField(value, fieldTextStyle, GUILayout.Width(50));

            // Draws an increment button that increases the value by 1
            if (GUILayout.Button(">", GUILayout.Width(25)))
            {
                value += 1.0;
            }

            // Ending with a flexible space allows the field to be centered
            GUILayout.FlexibleSpace();

            // This allows us to start a new line, since this row is done
            GUILayout.EndHorizontal();
        }
    }
}
