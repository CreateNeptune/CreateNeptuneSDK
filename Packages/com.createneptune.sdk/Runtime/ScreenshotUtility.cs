using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScreenshotUtility : MonoBehaviour
{
    public string fileName = "newScreenshot";
    public int superSize = 1;


    public void TakeScreenshot()
    {
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/" + fileName + ".png", superSize);
        Debug.Log("hey");
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(ScreenshotUtility))]
public class ScreenshotUtilityEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ScreenshotUtility myScript = (ScreenshotUtility)target;
        if (GUILayout.Button("Take Screenshot"))
        {
            myScript.TakeScreenshot();
        }
    }
}

#endif
