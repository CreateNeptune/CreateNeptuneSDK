using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;

namespace CreateNeptune.Addressables
{
    public class AddressablesBuildProcessor
    {
        /// <summary>
        /// AUTOMATIC BUILD
        /// </summary>

        private const string autoBuildMenuName = "Window/Asset Management/Addressables/Automatic Build";
        private const string autoBuildSettingName = "autoaddressables";
        private static bool BuildCheckIsEnabled
        {
            get => EditorPrefs.GetBool(autoBuildSettingName, false);
            set => EditorPrefs.SetBool(autoBuildSettingName, value);
        }

        [MenuItem(autoBuildMenuName)]
        private static void SetAutoAddressables()
        {
            // Add the auto-addressables setting to editor preferences if it doesn't already exist.
            if (!EditorPrefs.HasKey(autoBuildSettingName))
                EditorPrefs.SetBool(autoBuildSettingName, false);

            // Alter the setting and set checked / unchecked in the menu.
            BuildCheckIsEnabled = !BuildCheckIsEnabled;

            Debug.Log("Automatic Addressables " + EditorPrefs.GetBool(autoBuildSettingName));
        }

        [MenuItem(autoBuildMenuName, true)]
        private static bool SetAutoAddressablesValidate()
        {
            Menu.SetChecked(autoBuildMenuName, BuildCheckIsEnabled);

            return true;
        }

        /// <summary>
        /// PROFILE CHECK
        /// </summary>

        private const string profileSetMenuName = "Window/Asset Management/Addressables/Profile Set";
        private const string profileSetSettingName = "profileaddressables";
        private static bool ProfileCheckIsEnabled
        {
            get => EditorPrefs.GetBool(profileSetSettingName, false);
            set => EditorPrefs.SetBool(profileSetSettingName, value);
        }

        [MenuItem(profileSetMenuName)]
        private static void SetProfileCheck()
        {
            // Add the profile check setting to editor preferences if it doesn't already exist.
            if (!EditorPrefs.HasKey(profileSetSettingName))
                EditorPrefs.SetBool(profileSetSettingName, false);

            // Set checked / unchecked in the menu.
            ProfileCheckIsEnabled = !ProfileCheckIsEnabled;

            Debug.Log("Addressables Profile Check" + EditorPrefs.GetBool(profileSetSettingName));
        }

        [MenuItem(profileSetMenuName, true)]
        private static bool SetAddressablesProfileCheckValidate()
        {
            Menu.SetChecked(profileSetMenuName, ProfileCheckIsEnabled);

            return true;
        }

        /// <summary>
        /// BUILD PLAYER
        /// </summary>

        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            Debug.Log("Unity Automatic Addressables registered.");

            BuildPlayerWindow.RegisterBuildPlayerHandler(BuildPlayerHandler);
        }

        private static void BuildPlayerHandler(BuildPlayerOptions options)
        {
            // Shown profile check (if enabled)
            if (ProfileCheckIsEnabled)
                SetProfile(EditorUtility.DisplayDialogComplex("Choose Addressables Profile",
                    "Which Addressables Profile do you want to build with?\n(Must have profiles 'Remote' and 'Local')",
                    "Remote", "Local", "Skip"));

            // If you prefer just having Addressables built no matter what, set
            // "Autobuild Addressables" under Window.
            if (BuildCheckIsEnabled || EditorUtility.DisplayDialog("Build with Addressables",
                "Do you want to build clean Addressables before exporting?",
                "Build with Addressables", "Skip"))
            {
                PreExport();
            }

            BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(options);
        }

        ///<summary>
        /// Set the preferred profile for Addressables.
        /// </summary>
        private static void SetProfile(int dialogueChoice)
        {
            AddressableAssetSettings settings = AddressableAssetSettingsDefaultObject.Settings;

            switch (dialogueChoice)
            {
                case 0:
                    settings.BuildRemoteCatalog = true;
                    settings.activeProfileId = settings.profileSettings.GetProfileId("Remote");
                    break;
                case 1:
                    settings.BuildRemoteCatalog = false;
                    settings.activeProfileId = settings.profileSettings.GetProfileId("Local");
                    break;
                case 2:
                    break;
            }
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
}
