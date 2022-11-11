using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class SaveData : SaveDataSingleton<SaveData, SerialSaveData>
{
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