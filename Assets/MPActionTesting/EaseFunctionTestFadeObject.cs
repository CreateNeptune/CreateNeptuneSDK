using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTestFadeObject : EaseFunctionTest
{
    public float targetAlpha;

    public override void BeginTween()
    {
        CNExtensions.SafeStartCoroutine(this, ref tweenRoutine, CNAction.FadeObject(gameObject, animationTime, targetAlpha, CNEase.GetEasingFunc(easeType)));
    }
}
