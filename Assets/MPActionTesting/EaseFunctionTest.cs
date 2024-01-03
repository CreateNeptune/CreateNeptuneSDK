using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTest : MonoBehaviour
{
    public CNEase.EaseType easeType;
	public float animationTime = 1f;

	protected IEnumerator tweenRoutine;

	public virtual void BeginTween() {}
}
