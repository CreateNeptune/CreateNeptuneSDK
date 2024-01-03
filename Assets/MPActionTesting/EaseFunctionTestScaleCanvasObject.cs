using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTestScaleCanvasObject : EaseFunctionTest
{
    public float endScale = 5f;

    private RectTransform rectTransform;
    private Vector3 baseScale;

    private void Awake()
	{
        rectTransform = GetComponent<RectTransform>();
		baseScale = rectTransform.localScale;
	}

    public override void BeginTween()
    {
        CNExtensions.SafeStartCoroutine(this, ref tweenRoutine, CNAction.ScaleCanvasObject(gameObject, animationTime, Vector3.one * endScale, CNEase.GetEasingFunc(easeType)));
    }
}
