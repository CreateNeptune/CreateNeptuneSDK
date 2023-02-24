using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTest : MonoBehaviour
{
    public MPAction.EaseType easeType;
    public float animationTime;
    public float scaleMax;

	public void Start()
	{
		//StartCoroutine(MPAction.ScaleObject(gameObject, Vector3.zero, Vector3.one * scaleMax, animationTime, easeType, false, false, true));
	}

	public void OnValidate()
	{
		StopAllCoroutines();
		StartCoroutine(MPAction.ScaleObject(gameObject, Vector3.zero, Vector3.one * scaleMax, animationTime, easeType, false, false, false));
	}
}
