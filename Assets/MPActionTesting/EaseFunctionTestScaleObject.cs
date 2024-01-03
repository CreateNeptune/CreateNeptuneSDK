using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTestScaleObject : EaseFunctionTest
{
    public float endScale = 5f;

    private Vector3 baseScale;

    private void Awake()
	{
		baseScale = transform.localScale;
	}

    public override void BeginTween()
    {
        CNExtensions.SafeStartCoroutine(this, ref tweenRoutine, MPAction.ScaleObject(gameObject, Vector3.one * endScale, animationTime, easeType));
    }
}
