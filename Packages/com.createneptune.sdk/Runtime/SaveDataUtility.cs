using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

namespace CreateNeptune
{
    public static class SaveDataUtility
    {
#if UNITY_IOS
    private static readonly string fileName = Application.productName + "ios.data";
#elif UNITY_ANDROID
    private static readonly string fileName = Application.productName + "android.data";
#else
        private static readonly string fileName = Application.productName + "universal.data";
#endif

        public static bool loaded = false;

        // NOTE: Make sure all SerializedSaveData fields are included here.
        // *** Search the above "NOTE:..." to catch 'em all.
        public static int version;

        /// <summary>
        /// Read json save data, deserialize it into an instance class/struct T, then pass it to 
        /// the processing function
        /// </summary>
        /// <typeparam name="T">A serializable class</typeparam>
        /// <param name="deserializeAction">A function that takes an instance of T. 
        /// This function handles reading values into the class. </param>
        public static void LoadGame<T>(Action<T> deserializeAction)
        {
            string saveLocation = Application.persistentDataPath + "/" + fileName;

            try
            {
                if (File.Exists(saveLocation))
                {
                    string jsonData = File.ReadAllText(saveLocation);
                    T serializedSaveData = JsonUtility.FromJson<T>(jsonData);
                    deserializeAction(serializedSaveData);

                    Debug.Log($"Saved game loaded from {saveLocation}");
                }
                else
                {
                    Debug.Log("New user. No game saved.");
                }
            }
            catch (Exception e)
            {
                Debug.LogError("User save data corrupted.");
                Debug.LogError(e);
            }

            loaded = true;
            CreateNeptune.SaveDataLoadEvent.Instance.Invoke();
        }

        /// <summary>
        /// Write a serializable json structure to a file.
        /// </summary>
        /// <typeparam name="T">A serializable class</typeparam>
        /// <param name="serializeFunc">Serializing function. Returns a serializable struct to be written to a file.</param>
        public static void SaveGame<T>(Func<T> serializeFunc)
        {
            string saveLocation = Application.persistentDataPath + "/" + fileName;

            T serializedSaveData = serializeFunc();

            string jsonData = JsonUtility.ToJson(serializedSaveData, true);
            File.WriteAllText(saveLocation, jsonData);

            CreateNeptune.SaveDataSaveEvent.Instance.Invoke();
            Debug.Log("Game saved at " + saveLocation);
        }

        /// <summary>
        /// Loads a datum into a reference only if the datum to be loaded is not null
        /// (This prevents <see langword="null"/> references)
        /// </summary>
        /// <typeparam name="T">The type of the datum</typeparam>
        /// <param name="toLoadInto">The reference to load the datum into</param>
        /// <param name="loadedItem">The datum to be loaded</param>
        public static void SafeLoadDatum<T>(ref T toLoadInto, T loadedItem)
        {
            if (loadedItem != null)
                toLoadInto = loadedItem;
        }
    }
}

