using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;

public class AddressablesBuildProcessor
{
    private const string menuName = "Window/Asset Management/Addressables/Automatic Build";
    private const string settingName = "autoaddressables";
    private static bool IsEnabled
    {
        get => EditorPrefs.GetBool(settingName, false);
        set => EditorPrefs.SetBool(settingName, value);
    }

    [InitializeOnLoadMethod]
    private static void Initialize()
    {
        Debug.Log("Unity Automatic Addressables registered.");

        BuildPlayerWindow.RegisterBuildPlayerHandler(BuildPlayerHandler);
    }

    [MenuItem(menuName)]
    private static void SetAutoAddressables()
    {
        // Add the auto-addressables setting to editor preferences if it doesn't already exist.
        if (!EditorPrefs.HasKey(settingName))
            EditorPrefs.SetBool(settingName, false);

        // Alter the setting and set checked / unchecked in the menu.
        IsEnabled = !IsEnabled;

        Debug.Log("Automatic Addressables " + EditorPrefs.GetBool(settingName));
    }

    [MenuItem(menuName, true)]
    private static bool SetAutoAddressablesValidate()
    {
        Menu.SetChecked(menuName, IsEnabled);

        return true;
    }

    private static void BuildPlayerHandler(BuildPlayerOptions options)
    {
        // If you prefer just having Addressables built no matter what, set
        // "Autobuild Addressables" under Window.
        if (IsEnabled || EditorUtility.DisplayDialog("Build with Addressables",
            "Do you want to build clean Addressables before exporting?",
            "Build with Addressables", "Skip"))
        {
            PreExport();
        }

        BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(options);
    }
    ///<summary>
    /// Run a clean build before export.
    /// </summary>
    public static void PreExport()
    {
        Debug.Log("Building addressables pre-export.");
        AddressableAssetSettings.CleanPlayerContent(AddressableAssetSettingsDefaultObject.Settings.ActivePlayerDataBuilder);
        AddressableAssetSettings.BuildPlayerContent();
        Debug.Log("Pre-export complete.");
    }
}
