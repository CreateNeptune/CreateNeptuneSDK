using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTestRotateObject : EaseFunctionTest
{
    public float rotationDistance = 5f;

    private Vector3 baseRotation;

    private void Awake()
	{
		baseRotation = transform.rotation.eulerAngles;
	}

    public override void BeginTween()
    {
        Vector3 endRotation = baseRotation;
        endRotation.z += rotationDistance;
        CNExtensions.SafeStartCoroutine(this, ref tweenRoutine, CNAction.RotateObject(gameObject, animationTime, baseRotation, endRotation, CNEase.GetEasingFunc(easeType)));
    }
}
