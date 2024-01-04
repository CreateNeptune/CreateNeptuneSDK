using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTestMoveObject : EaseFunctionTest
{
    public float xDistance = 5f;

    private Vector3 basePosition;

    private void Awake()
	{
		basePosition = transform.position;
	}

    public override void BeginTween()
    {
        CNExtensions.SafeStartCoroutine(this, ref tweenRoutine, CNAction.MoveObject(gameObject, animationTime, basePosition, basePosition + Vector3.right * xDistance, CNEase.GetEasingFunc(easeType)));
    }
}
