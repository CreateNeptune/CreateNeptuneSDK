using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTest : MonoBehaviour
{
    public MPAction.EaseType easeType;
    public float animationTime;
    public float scaleMax;

	private IEnumerator scaleRoutine;

	public void OnValidate()
	{
		CNExtensions.SafeStartCoroutine(this, ref scaleRoutine, MPAction.ScaleObject(gameObject, Vector3.zero, Vector3.one * scaleMax, animationTime, easeType, false, false, true));
	}
}
