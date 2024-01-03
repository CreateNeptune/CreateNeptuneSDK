using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTestMoveCanvasObject : EaseFunctionTest
{
    public float xDistance = 5f;

    private RectTransform rectTransform;
    private Vector2 basePosition;

    private void Awake()
	{
        rectTransform = GetComponent<RectTransform>();
		basePosition = rectTransform.position;
	}

    public override void BeginTween()
    {
        CNExtensions.SafeStartCoroutine(this, ref tweenRoutine, MPAction.MoveCanvasObject(gameObject, animationTime, (Vector2)rectTransform.localPosition + Vector2.right * xDistance, easeType));
    }
}
