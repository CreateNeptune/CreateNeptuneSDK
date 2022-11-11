using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

namespace CreateNeptune
{
    public abstract class SaveDataUtility<T>
    {
#if UNITY_IOS
    private static readonly string fileName = Application.productName + "ios.data";
#elif UNITY_ANDROID
    private static readonly string fileName = Application.productName + "android.data";
#else
        private static readonly string fileName = Application.productName + "universal.data";
#endif

        /// <summary>
        /// Takes a serializable structure and read from its field
        /// </summary>
        /// <param name="dataStruct"></param>
        protected abstract void Deserialize(T dataStruct);
        /// <summary>
        /// Create a serializable structure that will be written to a file.
        /// </summary>
        /// <returns></returns>
        protected abstract T Serialize();

        /// <summary>
        /// Read json save data, deserialize it into an instance class/struct T, then pass it to 
        /// the processing function
        /// </summary>
        public void LoadGame()
        {
            string saveLocation = Application.persistentDataPath + "/" + fileName;

            try
            {
                if (File.Exists(saveLocation))
                {
                    string jsonData = File.ReadAllText(saveLocation);
                    T serializedSaveData = JsonUtility.FromJson<T>(jsonData);
                    Deserialize(serializedSaveData);

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

            SaveDataLoadEvent.Instance.Invoke();
        }

        /// <summary>
        /// Write a serializable json structure to a file.
        /// </summary>
        public void SaveGame()
        {
            string saveLocation = Application.persistentDataPath + "/" + fileName;

            T serializedSaveData = Serialize();

            string jsonData = JsonUtility.ToJson(serializedSaveData, true);
            File.WriteAllText(saveLocation, jsonData);

            SaveDataSaveEvent.Instance.Invoke();
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

