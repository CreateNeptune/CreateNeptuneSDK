using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTestColorObject : EaseFunctionTest
{
    public Color targetColor = Color.white;

    public override void BeginTween()
    {
        CNExtensions.SafeStartCoroutine(this, ref tweenRoutine, MPAction.ColorObject(gameObject, animationTime, targetColor, easeType));
    }
}
