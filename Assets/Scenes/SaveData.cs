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

public class SaveData : SaveDataSingleton<SaveData, SerialSaveData>
{
	public static string[] pigNames;
	public static float costPerPig;

	protected override void OnSuccessfulAwake()
	{
		costPerPig = 10; // pricey guinea pigs
		pigNames = new string[] { "Kiibow", "Teebow" };
	}

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