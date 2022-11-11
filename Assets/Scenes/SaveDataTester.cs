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

internal class SaveData : SaveDataUtility<SerialSaveData>
{
	public static SaveData Instance = new();

	public static string[] pigNames;
	public static float costPerPig;
	protected override void Deserialize(SerialSaveData dataStruct)
	{
		SafeLoadDatum(ref pigNames, dataStruct.pigNames);
		SafeLoadDatum(ref costPerPig, dataStruct.costPerPig);
	}

	protected override SerialSaveData Serialize()
	{
		return new()
		{
			pigNames = pigNames,
			costPerPig = costPerPig
		};
	}
}

public class SaveDataTester : MonoBehaviour
{
	public string[] pigNames;
	public float costPerPig;

	private void Awake()
	{

		Debug.Log("AWAKE");
		SaveData.Instance.LoadGame();

		pigNames = SaveData.pigNames;
		costPerPig = SaveData.costPerPig;
	}
	private void OnApplicationQuit()
	{
		SaveData.pigNames = pigNames;
		SaveData.costPerPig = costPerPig;

		Debug.Log("GONE");
		SaveData.Instance.SaveGame();
	}

	
}
