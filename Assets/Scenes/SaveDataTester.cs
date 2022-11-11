using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class SaveDataTester : MonoBehaviour
{
	public string[] pigNames;
	public float costPerPig;

	private void Start()
	{

		Debug.Log("Loading...");
		SaveData.Instance.LoadGame();

		pigNames = SaveData.Instance.pigNames;
		costPerPig = SaveData.Instance.costPerPig;
	}
	private void OnApplicationQuit()
	{
		SaveData.Instance.pigNames = pigNames;
		SaveData.Instance.costPerPig = costPerPig;

		Debug.Log("Saving...");
		SaveData.Instance.SaveGame();
	}

	
}
