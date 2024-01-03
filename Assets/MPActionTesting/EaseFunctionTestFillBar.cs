using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTestFillBar : EaseFunctionTest
{
    public float targetFill = 1f;

    public override void BeginTween()
    {
        CNExtensions.SafeStartCoroutine(this, ref tweenRoutine, MPAction.FillBar(gameObject, animationTime, targetFill, easeType));
    }
}
