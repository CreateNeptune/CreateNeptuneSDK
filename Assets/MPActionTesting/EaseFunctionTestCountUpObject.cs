using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTestCountUpObject : EaseFunctionTest
{
    public int targetValue = 100;

    public override void BeginTween()
    {
        CNExtensions.SafeStartCoroutine(this, ref tweenRoutine, MPAction.CountUpObject(gameObject, targetValue, animationTime, easeType));
    }
}
