using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

namespace CreateNeptune
{
    public abstract class SaveDataSingleton<TExtendedClass, TSerializedClass> : Singleton<TExtendedClass>
        where TExtendedClass : class
    {
        public bool loaded { get; private set; }

        private string fileName;
        public string FileName
        {
            get
            {
                if (fileName is null || fileName == "")
                {
#if UNITY_IOS
                    fileName = Application.productName + "ios.data";
#elif UNITY_ANDROID
                    fileName = Application.productName + "android.data";
#else
                    fileName = Application.productName + "universal.data";
#endif
                }

                return fileName;
            }
        }

        /// <summary>
        /// child classes should override this to have some some initial data before anything gets loaded. 
        /// </summary>
        protected override void OnSuccessfulAwake()
        {
            SetDefaultValues();
        }

        /// <summary>
        /// Takes a serializable structure and read from its field
        /// </summary>
        /// <param name="dataStruct"></param>
        protected abstract void Deserialize(TSerializedClass dataStruct);
        /// <summary>
        /// Create a serializable structure that will be written to a file.
        /// </summary>
        /// <returns></returns>
        protected abstract TSerializedClass Serialize();

        /// <summary>
        /// Called after a game has been written to file, before any event is sent out
        /// </summary>
        protected virtual void OnGameSaved() { }

        /// <summary>
        /// Read json save data from persistent path, then pass it to the processing function.
        /// When operations are successfully completed, set the loaded to TRUE, meaning the
        /// save data was successfully loaded.
        /// </summary>
        public void LoadGame()
        {
            string saveLocation = Application.persistentDataPath + "/" + FileName;

            try
            {
                if (File.Exists(saveLocation))
                {
                    string jsonData = File.ReadAllText(saveLocation);
                    ProcessJSON(jsonData);

                    Debug.Log($"Saved game loaded from {saveLocation}");
                }
                else
                {
                    Debug.Log("New user. No game saved.");
                }
                loaded = true;
            }
            catch (Exception e)
            {
                Debug.LogError("User save data corrupted.");
                Debug.LogError(e);
            }

            SaveDataLoadedEvent.Instance.Invoke();
        }

        /// <summary>
        /// Reads the JSON-formatted save data, deserializes it into an instance of the specified class or struct (T), 
        /// and then passes it to the designated processing function for further handling.
        /// This method provides a centralized point for managing the deserialization process, allowing customization 
        /// in child classes. 
        /// 
        /// Note: It can be overridden (optional) to implement additional functionality, such as version checking 
        /// to support seamless transitions of data between different save data formats (TSerializedClass).
        /// </summary>
        /// <param name="jsonData">The JSON-formatted string containing serialized save data.</param>
        protected virtual void ProcessJSON(string jsonData)
        {
            TSerializedClass serializedSaveData = JsonUtility.FromJson<TSerializedClass>(jsonData);
            Deserialize(serializedSaveData);
        }

        /// <summary>
        /// Write a serializable json structure to a file.
        /// </summary>
        public void SaveGame()
        {
            string saveLocation = Application.persistentDataPath + "/" + FileName;

            TSerializedClass serializedSaveData = Serialize();

            if (serializedSaveData == null)
            {
                Debug.Log("Save data object is null, so not saving game.");
                return;
            }

            string jsonData = JsonUtility.ToJson(serializedSaveData, true);
            File.WriteAllText(saveLocation, jsonData);

            OnGameSaved();
            SaveDataSavedEvent.Instance.Invoke();
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

        /// <summary>
        /// Use this whenever you need to reset or unload save data
        /// </summary>
        protected virtual void SetDefaultValues()
        {
            loaded = false;
        }
    }
}

