using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

[System.Serializable]
public class SerialSaveData
{
	public string[] pigNames;
	public float costPerPig;
}

public class SaveData : MonoBehaviour
{
	public SerialSaveData saveData;

	private void Awake()
	{
		Debug.Log("AWAKE");
		SaveDataUtility.LoadGame<SerialSaveData>(SaveDeserialize);
		
	}
	private void OnApplicationQuit()
	{
		Debug.Log("GONE");
		SaveDataUtility.SaveGame(SaveSerialize);
	}

	private void SaveDeserialize(SerialSaveData serialSaveData)
	{
		SaveDataUtility.SafeLoadDatum(ref saveData.costPerPig, serialSaveData.costPerPig);
		SaveDataUtility.SafeLoadDatum(ref saveData.pigNames, serialSaveData.pigNames);
	}

	private SerialSaveData SaveSerialize()
	{
		return saveData;
	}
}
